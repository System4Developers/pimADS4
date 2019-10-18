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

            if (usuario.DsLogin !="" && usuario.DsSenha !="")
            {
                UsuarioDAO.GetInstance().CadastrarUsuario(usuario);
            }

        }

        internal List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioDAO.GetInstance().ConsultarUsuarioTodos();
            return lstUsuarios;
        }
    }
}
