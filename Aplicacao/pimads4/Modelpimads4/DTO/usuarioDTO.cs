using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class UsuarioDTO
    {
        private int idUsuario;
        private string tipoUsuairo;
        private string dsLogin;
        private String senha;
        private string tipoStatus;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string TipoUsuairo { get => tipoUsuairo; set => tipoUsuairo = value; }
        public string DsLogin { get => dsLogin; set => dsLogin = value; }
        public string Senha { get => senha; set => senha = value; }
        public string TipoStatus { get => tipoStatus; set => tipoStatus = value; }


    }
}
