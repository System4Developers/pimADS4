using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class UsuarioDAO
    {
        private static UsuarioDAO instance;

        private UsuarioDAO() { }

        public static UsuarioDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new UsuarioDAO();
            }
            return instance;
        }

        internal void CadastrarUsuario(UsuarioDTO usuario)
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_CadastrarUsuario", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tpUsuario", usuario.TpUsuario);
            cmd.Parameters.AddWithValue("@dsLogin", usuario.DsLogin);
            cmd.Parameters.AddWithValue("@dsSenha", usuario.DsSenha);
            cmd.Parameters.AddWithValue("@tpStatus", usuario.TpStatus);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

    }
}
