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
        private String mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

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
            this.Mensagem = "";
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
                this.Mensagem = "FALHA AO CADASTRAR USUÁRIO";
            }

        }

        internal List<UsuarioDTO> ConsultarUsuarioTodos()
        {
            this.Mensagem = "";
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
                this.Mensagem = "FALHA AO CONSULTAR USUÁRIOS";
            }
            return lstUsuarios;
        }

        internal List<UsuarioDTO> ConsultarUsuarioByNmLogin(string nmUsuario, string dsLogin)
        {
            this.Mensagem = "";

            String sqlText = "SELECT * FROM Usuarios";
            if (nmUsuario !=""  && dsLogin=="")
            {
                sqlText += " WHERE nmUsuario like '%"+ nmUsuario +"%'";
            }
            if (nmUsuario =="" && dsLogin !="")
            {
                sqlText += " WHERE dsLogin like '%" + dsLogin + "%'";
            }
            if (nmUsuario != "" && dsLogin != "")
            {
                sqlText += " WHERE dsLogin like '%" + dsLogin + "%' AND nmUsuario like '%" + nmUsuario + "%'";
            }
            UsuarioDTO usuario = null;
            List<UsuarioDTO> listaUsuario = new List<UsuarioDTO>();

            SqlCommand cmd  = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

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

                    listaUsuario.Add(usuario);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "NAO FOI POSSIVEL CONSULTAR USUARIO";
            }
            return listaUsuario;
        }

        internal UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            this.Mensagem = "";
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
                this.Mensagem = "FALHA AO OBTER DADOS DO USUARIO ID: " + idUsuario; 
            }
            return usuario;
        }

        internal void AtualizarUsuario(UsuarioDTO usuario)
        {
            this.Mensagem = "";
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
                this.Mensagem = "FALHA AO ATUALIZAR DADOS DO USUARIO";
            }

        }

        internal void ExlcuirUsuario(int idUsuario)
        {
            this.Mensagem = "";
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
                this.Mensagem = "FALHA AO EXLCUIR USUÁRIO";
            }

        }

        internal void ValidarLoginUsuario(String Ds_Login,String Ds_Senha)
        {
            this.Mensagem = "";

            String sqlText = "SELECT * FROM Usuarios WHERE " +
                "dsLogin ="+ "'" + Ds_Login  +"'" + " AND " + 
                "dsSenha =" + "'" + Ds_Senha + "'" + "AND " +
                "tpStatus='S'";
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
                this.Mensagem = "FALHA AO VALIDADAR LOGIN DO USUÁRIO"; 
            }
        }

    }
}
