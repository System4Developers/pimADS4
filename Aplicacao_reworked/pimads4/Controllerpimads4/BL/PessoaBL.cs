using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PessoaBL
    {
        private static PessoaBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PessoaBL() { }

        public static PessoaBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PessoaBL();
            }

            return instance;
        }

        internal void CadastrarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";
            if (pessoa.NmPessoa != "")
            {
                PessoaDAO.GetInstance().CadastrarPessoa(pessoa);
                if (PessoaDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = PessoaDAO.GetInstance().Mensagem;
                }
            }
        }
        internal List<PessoaDTO> ConsultarPessoas()
        {
            this.Mensagem = "";
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaDAO.GetInstance().ConsultarPessoaTodos();
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return lstPessoas;
        }
        internal PessoaDTO ConsultarPessoaById(int idPessoa)
        {
            this.Mensagem = "";
            PessoaDTO pessoa = PessoaDAO.GetInstance().ConsultarPessoaById(idPessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return pessoa;
        }
        internal void AtualizarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";
            PessoaDAO.GetInstance().AtualizarPessoa(pessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
        }
        internal void ExcluirPessoa(int idPessoa)
        {
            this.Mensagem = "";
            PessoaDAO.GetInstance().ExlcuirPessoa(idPessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
        }
        internal List<PessoaDTO> ConsultarPessoaJuridica()
        {
            this.Mensagem = "";
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            listaPessoaJuridica = PessoaDAO.GetInstance().ConsultarPessoaJuridica();
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return listaPessoaJuridica;
        }
    }
}
