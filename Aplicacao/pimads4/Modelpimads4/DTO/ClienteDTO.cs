using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class ClienteDTO
    {
        private int idCliente;
        private string nome;
        private string cpf;
        private string dtNascimento;
        private string estadoCivil;
        private string rg;
        private string dsObs;
        private string razaoSocial;
        private string tipoStatus;
        private string tipo;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string Rg { get => rg; set => rg = value; }
        public string DsObs { get => dsObs; set => dsObs = value; }
        public string RazaoSocial { get => razaoSocial; set => razaoSocial = value; }
        public string TipoStatus { get => tipoStatus; set => tipoStatus = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
