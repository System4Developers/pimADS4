using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class ConexaoDAO
    {
        public static ConexaoDAO instance;
        private String connString;
        private static SqlConnection con;

        private ConexaoDAO()
        {
            connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
        }

        public static ConexaoDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new ConexaoDAO();
            }
            return instance;
        }

        public SqlConnection Conexao()
        {
            con = new SqlConnection(connString);
            return con;
        }
       
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void Desconectar()
        {

            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }

    }
}
