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
            cmd.Parameters.AddWithValue("@dsLogin", usuario.DsLogin);
            cmd.Parameters.AddWithValue("@dsSenha", usuario.DsSenha);
            cmd.Parameters.AddWithValue("@tpStatus", usuario.TpStatus);
            cmd.Parameters.AddWithValue("@nmUsuario", usuario.NmUsuario);
            cmd.Parameters.AddWithValue("@tpUsuario", usuario.TpUsuario);

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

        internal List<UsuarioDTO> ConsultarUsuarioTodos()
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "SELECT * FROM Usuarios";
            SqlCommand cmd = new SqlCommand(sqlText, conn);
            
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    usuario.DsLogin = dr["dsLogin"].ToString();
                    usuario.TpStatus = dr["tpStatus"].ToString();
                    usuario.TpUsuario = dr["tpUsuario"].ToString();

                    lstUsuarios.Add(usuario);
                }

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
            return lstUsuarios;
        }

        internal UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioById", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            UsuarioDTO usuario = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    usuario.DsLogin = dr["dsLogin"].ToString();
                    usuario.DsSenha = dr["dsSenha"].ToString();
                    usuario.TpStatus = dr["tpStatus"].ToString();
                    usuario.NmUsuario = dr["nmUsuario"].ToString();
                    usuario.TpUsuario = dr["tpUsuario"].ToString();
                }
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
            return usuario;
        }

        internal void AtualizarUsuario(UsuarioDTO usuario)
        {
            string connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_AtualizarUsuario", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario",usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@dsLogin", usuario.DsLogin);
            cmd.Parameters.AddWithValue("@dsSenha", usuario.DsSenha);
            cmd.Parameters.AddWithValue("@tpStatus", usuario.TpStatus);
            cmd.Parameters.AddWithValue("@nmUsuario", usuario.NmUsuario);
            cmd.Parameters.AddWithValue("@tpUsuario", usuario.TpUsuario);

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
