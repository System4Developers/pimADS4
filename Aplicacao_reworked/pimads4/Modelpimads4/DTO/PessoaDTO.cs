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
        private string tpPessoa;
        private string nmPessoa;
        private string numDocumento;
        private string numRG;
        private string dtNascimento;
        private string dsEmail;
        private string dsEndereco;
        private string complemento;
        private string numEnd;
        private string observacao;
        private BairroDTO bairro;

        public int IdPessoa { get => idPessoa; set => idPessoa = value; }
        public string TpPessoa { get => tpPessoa; set => tpPessoa = value; }
        public string NmPessoa { get => nmPessoa; set => nmPessoa = value; }
        public string NumDocumento { get => numDocumento; set => numDocumento = value; }
        public string NumRG { get => numRG; set => numRG = value; }
        public string DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public string DsEmail { get => dsEmail; set => dsEmail = value; }
        public string DsEndereco { get => dsEndereco; set => dsEndereco = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string NumEnd { get => numEnd; set => numEnd = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public BairroDTO Bairro { get => bairro; set => bairro = value; }

        public PessoaDTO()
        {
            Bairro = new BairroDTO();
        }

    }
}
