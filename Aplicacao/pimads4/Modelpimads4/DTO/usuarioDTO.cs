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
        private string tpUsuairo;
        private string dsLogin;
        private String senha;
        private string tpStatus;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string TpUsuairo { get => tpUsuairo; set => tpUsuairo = value; }
        public string DsLogin { get => dsLogin; set => dsLogin = value; }
        public string Senha { get => senha; set => senha = value; }
        public string TpStatus { get => tpStatus; set => tpStatus = value; }


    }
}
