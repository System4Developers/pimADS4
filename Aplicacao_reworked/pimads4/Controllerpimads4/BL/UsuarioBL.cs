using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllerpimads4.DAO;
using Modelpimads4.DTO;

namespace Controllerpimads4.BL
{
    public class UsuarioBL
    {
        private static UsuarioBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private UsuarioBL() { }

        public static UsuarioBL GetInstance()
        {
            if (instance == null)
            {
                instance = new UsuarioBL();
            }

            return instance;
        }

        internal void CadastrarUsuario(UsuarioDTO usuario)
        {
            this.Mensagem = "";
            if (usuario.DsLogin !="" && usuario.DsSenha !="")
            {
                UsuarioDAO.GetInstance().CadastrarUsuario(usuario);
                if (UsuarioDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = UsuarioDAO.GetInstance().Mensagem;
                }
            }

        }

        internal List<UsuarioDTO> ConsultarUsuarios()
        {
            this.Mensagem = "";
            if (UnidadeDAO.GetInstance().Mensagem!="")
            {
                this.Mensagem = UnidadeDAO.GetInstance().Mensagem;
            }
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioDAO.GetInstance().ConsultarUsuarioTodos();
            return lstUsuarios;
        }

        internal UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            this.Mensagem = "";
            UsuarioDTO usuario = UsuarioDAO.GetInstance().ConsultarUsuarioById(idUsuario);
            if (UsuarioDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioDAO.GetInstance().Mensagem;
            }
            return usuario;
        }

        internal void AtualizarUsuario(UsuarioDTO usuario)
        {
            this.Mensagem = "";
            UsuarioDAO.GetInstance().AtualizarUsuario(usuario);
            if (UsuarioDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioDAO.GetInstance().Mensagem;
            }

        }

        internal void ExcluirUsuario(int idUsuario)
        {
            this.Mensagem = "";
            UsuarioDAO.GetInstance().ExlcuirUsuario(idUsuario);
            if (UsuarioDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioDAO.GetInstance().Mensagem;
            }
        }

        internal void ValidarLoginUsuario(String Ds_Login, String Ds_Senha)
        {
            this.Mensagem = "";
            if (Ds_Login !="" && Ds_Senha !="")
            {
                UsuarioDAO.GetInstance().ValidarLoginUsuario(Ds_Login, Ds_Senha);
                if (UsuarioDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = UsuarioDAO.GetInstance().Mensagem;
                }
            }
        }
    }
}
