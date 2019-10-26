using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelpimads4.DTO;
using Controllerpimads4.BL;

namespace Controllerpimads4.Controller
{
    public class Controller
    {
        private static Controller instance;

        private Controller() { }

        public static Controller GetInstance()
        {
            if (instance==null)
            {
                instance = new Controller();
            }

            return instance;
        }
       
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().CadastrarUsuario(usuario);
            
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioBL.GetInstance().ConsultarUsuarios();
            return lstUsuarios;
        }

        public UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            UsuarioDTO usuario = UsuarioBL.GetInstance().ConsultarUsuarioById(idUsuario);
            return usuario;
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().AtualizarUsuario(usuario);
        }
    }
}
