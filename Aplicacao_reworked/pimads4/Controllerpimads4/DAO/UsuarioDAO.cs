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
            SqlCommand cmd = new SqlCommand("sp_CadastrarUsuario", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dsLogin", usuario.DsLogin);
            cmd.Parameters.AddWithValue("@dsSenha", usuario.DsSenha);
            cmd.Parameters.AddWithValue("@tpStatus", usuario.TpStatus);
            cmd.Parameters.AddWithValue("@nmUsuario", usuario.NmUsuario);
            cmd.Parameters.AddWithValue("@tpUsuario", usuario.TpUsuario);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
                
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

        internal List<UsuarioDTO> ConsultarUsuarioTodos()
        {
            String sqlText = "SELECT * FROM Usuarios";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            UsuarioDTO usuario = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                    usuario.NmUsuario = dr["nmUsuario"].ToString();
                    usuario.DsLogin = dr["dsLogin"].ToString();
                    usuario.TpStatus = dr["tpStatus"].ToString();
                    usuario.TpUsuario = dr["tpUsuario"].ToString();

                    lstUsuarios.Add(usuario);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstUsuarios;
        }

        internal UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarioById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            UsuarioDTO usuario = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
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
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return usuario;
        }

        internal void AtualizarUsuario(UsuarioDTO usuario)
        {
            SqlCommand cmd = new SqlCommand("sp_AtualizarUsuario", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario",usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@dsLogin", usuario.DsLogin);
            cmd.Parameters.AddWithValue("@dsSenha", usuario.DsSenha);
            cmd.Parameters.AddWithValue("@tpStatus", usuario.TpStatus);
            cmd.Parameters.AddWithValue("@nmUsuario", usuario.NmUsuario);
            cmd.Parameters.AddWithValue("@tpUsuario", usuario.TpUsuario);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

        internal void ExlcuirUsuario(int idUsuario)
        {
            SqlCommand cmd = new SqlCommand("sp_ExcluirUsuario", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario",idUsuario);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

        internal void ValidarLoginUsuario(String Ds_Login,String Ds_Senha)
        {
            String sqlText = "SELECT * FROM Usuarios WHERE " +
                "dsLogin ="+ "'" + Ds_Login  +"'" + " AND " + 
                "dsSenha =" + "'" + Ds_Senha + "'";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        estPropriedades.Bl_Logado = true;
                        estPropriedades.Id_Usuario = Convert.ToInt32(dr["idUsuario"].ToString());
                        estPropriedades.Nm_Usuario = dr["nmUsuario"].ToString();
                        estPropriedades.Tp_Usuario = dr["tpUsuario"].ToString();
                    }
                    
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
        }

    }
}
