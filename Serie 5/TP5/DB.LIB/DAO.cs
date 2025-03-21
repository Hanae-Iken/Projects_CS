using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace DB.LIB
{
    public class DAO : Connexion, IDAO<object>
    {
        public int id = 0;
        //private string sql ;

        public DAO()
        {
            using (Connexion connexion = new Connexion())
            {
                connexion.Connect("ensat");
            }

        }

        public Dictionary<string, object> ObjectToDictionary()
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                object value = p.GetValue(this);
                if (value != null)
                {
                    if (p.Name == "Id" && value.ToString() != "0" && !string.IsNullOrEmpty(value.ToString()))
                        dico["id"] = value;
                    else if (p.Name != "Id")
                        dico[p.Name] = value;
                }
            }
            return dico;
        }

        public int insert()
        {
            Dictionary<string, object> properties = ObjectToDictionary();
            string columns = string.Join(",", properties.Keys);
            string values = string.Join(",", properties.Keys.Select(key => "@" + key));
            string sql = $"INSERT INTO {this.GetType().Name.ToLower()} ({columns}) VALUES ({values})";
            return iud(sql, properties);
        }

        public int update()
        {
            Dictionary<string, object> properties = ObjectToDictionary();
            string setClause = string.Join(",", properties.Keys.Where(key => key != "Id").Select(key => $"{key} = @{key}"));
            string sql = $"UPDATE {this.GetType().Name.ToLower()} SET {setClause} WHERE Id = @Id";
            return iud(sql, properties);
        }

        public int delete()
        {
            string sql = $"DELETE FROM {this.GetType().Name.ToLower()} WHERE Id = @Id";
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "@Id", this.GetType().GetProperty("Id")?.GetValue(this) }
            };
            return iud(sql, param);
        }

        public object findById()
        {
            object idValue = this.GetType().GetProperty("Id")?.GetValue(this);
            if (idValue == null)
                throw new InvalidOperationException("La propriété 'Id' n'est pas définie.");

            string sql = $"SELECT * FROM {this.GetType().Name.ToLower()} WHERE Id = @Id";
            Dictionary<string, object> param = new Dictionary<string, object>()
            {
                { "@Id", idValue }
            };

            MySqlDataReader reader = (MySqlDataReader)select(sql, param);
            if (reader.Read())
            {
                object result = Activator.CreateInstance(this.GetType());
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    if (reader[prop.Name] != DBNull.Value)
                        prop.SetValue(result, reader[prop.Name]);
                }
                return result;
            }
            return null;
        }

        public List<object> findAll()
        {
            List<object> list = new List<object>();
            string sql = $"SELECT * FROM {this.GetType().Name.ToLower()}";

            MySqlDataReader reader = (MySqlDataReader)select(sql);
            while (reader.Read())
            {
                object obj = Activator.CreateInstance(this.GetType());
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    if (reader[prop.Name] != DBNull.Value)
                        prop.SetValue(obj, reader[prop.Name]);
                }
                list.Add(obj);
            }
            return list;
        }

        public List<object> find()
        {
            Dictionary<string, object> properties = ObjectToDictionary();
            if (properties == null || properties.Count == 0)
                throw new InvalidOperationException("Aucune propriété valide pour la recherche.");

            string whereClause = string.Join(" AND ", properties.Keys.Select(key => $"{key} = @{key}"));
            string sql = $"SELECT * FROM {this.GetType().Name.ToLower()} WHERE {whereClause}";

            MySqlDataReader reader = (MySqlDataReader)select(sql, properties);
            List<object> list = new List<object>();
            while (reader.Read())
            {
                object obj = Activator.CreateInstance(this.GetType());
                foreach (PropertyInfo prop in this.GetType().GetProperties())
                {
                    if (reader[prop.Name] != DBNull.Value)
                        prop.SetValue(obj, reader[prop.Name]);
                }
                list.Add(obj);
            }
            return list;
        }

        public object DictionaryToObject(Dictionary<string, object> dico)
        {
            if (dico == null)
                throw new ArgumentNullException(nameof(dico), "Le dictionnaire ne peut pas être null.");

            object obj = Activator.CreateInstance(this.GetType());
            foreach (var kvp in dico)
            {
                PropertyInfo prop = this.GetType().GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(obj, kvp.Value);
                }
            }
            return obj;
        }
    }
}