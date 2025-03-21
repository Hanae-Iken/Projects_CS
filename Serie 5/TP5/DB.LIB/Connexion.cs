using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB.LIB
{
    public class Connexion: IConnexion
    {
        MySqlConnection cnx;
        MySqlCommand cmd;

        public Connexion()
        {
            /* chargement des paramètres de connexion à partir d'un
            fichier d'environnement */
            // construction de la chaine de connexion en fonction du SGBD
        }

        public void Connect(string db_name, string host = "localhost", string username = "root", string password = "")
        {
            string chaine_cnx = $"User Id={username};Password={password}; Host={host};Database={db_name}";
            cnx = new MySqlConnection(chaine_cnx);
            cnx.Open();
            cmd = new MySqlCommand();
            cmd.Connection = cnx;
        }

        public int iud(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            if (parameters != null)
                foreach (var param in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = param.Key;
                    p.Value = param.Value;
                    cmd.Parameters.Add(p);
                }
            return cmd.ExecuteNonQuery();

        }

        public void Dispose()
        {
            if (cmd != null)
                cmd.Dispose();
            if (cnx != null && cnx.State == ConnectionState.Open)
                cnx.Close();
        }

        public IDataReader select(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            if (parameters != null)
                foreach (var param in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = param.Key;
                    p.Value = param.Value;
                    cmd.Parameters.Add(p);
                }
            return cmd.ExecuteReader();
        }

    }
}
