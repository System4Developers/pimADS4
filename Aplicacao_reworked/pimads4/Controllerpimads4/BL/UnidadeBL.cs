using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class UnidadeBL
    {
        private static UnidadeBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private UnidadeBL() { }

        public static UnidadeBL GetInstance()
        {

            if (instance == null)
            {
                instance = new UnidadeBL();
            }

            return instance;
        }


        internal void CadastrarUnidade(UnidadeDTO unidade)
        {
            this.Mensagem = "";
            if (unidade.DsUnidade !="")
            {
                UnidadeDAO.GetInstance().CadastrarUnidade(unidade);
            }

        }

        internal List<UnidadeDTO> ConsultarUnidades()
        {
            this.Mensagem = "";
            List<UnidadeDTO> lstUnidades = new List<UnidadeDTO>();
            lstUnidades = UnidadeDAO.GetInstance().ConsultarUnidadeTodos();
            if (UnidadeDAO.GetInstance().Mensagem!="")
            {
                this.Mensagem = UnidadeDAO.GetInstance().Mensagem;
            }
            return lstUnidades;
        }

        internal UnidadeDTO ConsultarUnidadeById(int idUnidade)
        {
            this.Mensagem = "";
            UnidadeDTO unidade = UnidadeDAO.GetInstance().ConsultarUnidadeById(idUnidade);
            if (UnidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeDAO.GetInstance().Mensagem;
            }
            return unidade;
        }

        internal void AtualizarUnidade(UnidadeDTO unidade)
        {
            this.Mensagem = "";
            UnidadeDAO.GetInstance().AtualizarUnidade(unidade);
            if (UnidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeDAO.GetInstance().Mensagem;
            }
        }

        internal void ExcluirUnidade(int idUnidade)
        {
            this.Mensagem = "";
            UnidadeDAO.GetInstance().ExlcuirUnidade(idUnidade);
            if (UnidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeDAO.GetInstance().Mensagem;
            }
        }
 
    }
}
