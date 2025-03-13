using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gestion_Ecole
{
    internal class DAOEleve : Connexion, IDAO<Eleve>
    {
        public DAOEleve()
        {
            Connect("ensat");
        }
        public int delete(int id)
        {
            string sql = "delete from eleve where id=@id";
            Dictionary<string, object> param = new Dictionary<string, object>() { { "@id",id} };
            return iud(sql,param) ;
        }

        public List<Eleve> find(Eleve o)
        {
            List<Eleve> list = new List<Eleve>();
            MySqlDataReader reader = null;

            string sql = "select * from eleve where ";
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico = o.ObjToDico();
            foreach (var p in dico)
                sql += p.Key + "=" + "@" + p.Key + " and ";
            sql += "1=1";

            reader = (MySqlDataReader)select(sql, dico);

            while (reader.Read())
                list.Add(new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4)));
            return list;
        }

        public string testfind(Eleve o)
        {
            List<Eleve> list = new List<Eleve>();
            MySqlDataReader reader = null;

            string sql = "select * from eleve where ";
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico = o.ObjToDico();
            foreach (var p in dico)
                sql += p.Key + "=" + p.Value + " and ";
            sql += "1=1";

           
            return sql;
        }

        public List<Eleve> findAll()
        {
            List<Eleve> list = new List<Eleve>();
            MySqlDataReader reader = null;

            string sql = "select * from eleve";
           
            reader = (MySqlDataReader)select(sql);

            while (reader.Read())
                list.Add(new Eleve(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                    reader.GetString(3), reader.GetString(4)));
            return list;
        }

        public Eleve findById(int id)
        {
            MySqlDataReader reader = null;

            string sql = "select * from eleve where id = @id";

            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("id", id);

            reader = (MySqlDataReader)select(sql, dico);

            if (reader.Read())
            {
                return new Eleve(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4)
                );
            }

            return null;
        }

        public int insert(Eleve o)
        {
            string sql = "insert into eleve(nom,prenom,ville,specialite)" +
                "values(@nom,@prenom,@ville,@specialite)";
            Dictionary<string, object> param = new Dictionary<string, object>() {
                { "@nom", o.Nom },
                { "@prenom", o.Prenom },
                { "@ville", o.Ville },
                { "@specialite", o.Specialite },
                };
            return iud(sql, param);
        }

        public int update(Eleve o)
        {
                 string sql = "UPDATE eleve SET nom = @nom, prenom = @prenom, ville = @ville, specialite = @specialite WHERE id = @id";

                 Dictionary<string, object> param = new Dictionary<string, object>()
                {
                    { "@id", o.Id },
                    { "@nom", o.Nom },
                    { "@prenom", o.Prenom },
                    { "@ville", o.Ville },
                    { "@specialite", o.Specialite }
                };

                        return iud(sql, param);
        }

    }
}
