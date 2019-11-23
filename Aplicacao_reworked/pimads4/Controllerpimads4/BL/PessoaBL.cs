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
            if (pessoa.NmPessoa != "")
            {
                PessoaDAO.GetInstance().CadastrarPessoa(pessoa);
            }
        }
        internal List<PessoaDTO> ConsultarPessoas()
        {
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaDAO.GetInstance().ConsultarPessoaTodos();
            return lstPessoas;
        }
        internal PessoaDTO ConsultarPessoaById(int idPessoa)
        {
            PessoaDTO pessoa = PessoaDAO.GetInstance().ConsultarPessoaById(idPessoa);
            return pessoa;
        }
        internal void AtualizarPessoa(PessoaDTO pessoa)
        {
            PessoaDAO.GetInstance().AtualizarPessoa(pessoa);
        }
        internal void ExcluirPessoa(int idPessoa)
        {
            PessoaDAO.GetInstance().ExlcuirPessoa(idPessoa);
        }
        internal List<PessoaDTO> ConsultarPessoaJuridica()
        {
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            listaPessoaJuridica = PessoaDAO.GetInstance().ConsultarPessoaJuridica();
            return listaPessoaJuridica;
        }
    }
}
