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
        private string tpUsuario;
        private string dsLogin;
        private String dsSenha;
        private string tpStatus;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string TpUsuario { get => tpUsuario; set => tpUsuario = value; }
        public string DsLogin { get => dsLogin; set => dsLogin = value; }
        public string DsSenha { get => dsSenha; set => dsSenha = value; }
        public string TpStatus { get => tpStatus; set => tpStatus = value; }


    }
}
