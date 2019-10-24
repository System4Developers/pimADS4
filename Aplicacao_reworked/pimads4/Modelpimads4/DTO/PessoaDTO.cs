using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class PessoaDTO
    {
        private int idPessoa;
        private string nmPessoa;
        private string tpPessoa;
        private string numCPF;
        private string numRG;
        private string nmRazaoSocial;
        private string dsObs;
        private string dsEstadoCivil;
        private string dsStatus;
        private string numCNPJ;
        private string dsEmail;
        private string dtNascimento;
        private string dsComplemento;
        private string dsEndereco;
        private string numEndereco;
        private BairroDTO bairro;

        public int IdPessoa { get => idPessoa; set => idPessoa = value; }
        public string NmPessoa { get => nmPessoa; set => nmPessoa = value; }
        public string TpPessoa { get => tpPessoa; set => tpPessoa = value; }
        public string NumCPF { get => numCPF; set => numCPF = value; }
        public string NumRG { get => numRG; set => numRG = value; }
        public string NmRazaoSocial { get => nmRazaoSocial; set => nmRazaoSocial = value; }
        public string DsObs { get => dsObs; set => dsObs = value; }
        public string DsEstadoCivil { get => dsEstadoCivil; set => dsEstadoCivil = value; }
        public string DsStatus { get => dsStatus; set => dsStatus = value; }
        public string NumCNPJ { get => numCNPJ; set => numCNPJ = value; }
        public string DsEmail { get => dsEmail; set => dsEmail = value; }
        public string DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public string DsComplemento { get => dsComplemento; set => dsComplemento = value; }
        public string DsEndereco { get => dsEndereco; set => dsEndereco = value; }
        public string NumEndereco { get => numEndereco; set => numEndereco = value; }
        public BairroDTO Bairro { get => bairro; set => bairro = value; }


        public PessoaDTO()
        {
            Bairro = new BairroDTO();
        }

    }
}
