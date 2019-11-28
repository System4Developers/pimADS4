using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class CidadeBL
    {
        private static CidadeBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private CidadeBL() { }

        public static CidadeBL GetInstance()
        {
            if (instance==null)
            {
                instance = new CidadeBL();
            }

            return instance;
        }

        internal void CadastrarCidade(CidadeDTO cidade)
        {
            this.Mensagem = "";
            if (cidade.NmCidade != "")
            {
                CidadeDAO.GetInstance().CadastrarCidade(cidade);
                if (CidadeDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = CidadeDAO.GetInstance().Mensagem;
                }
            }
        }

        internal List<CidadeDTO> ConsultarCidades()
        {
            this.Mensagem = "";
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadeTodos();
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeDAO.GetInstance().Mensagem;
            }
            return lstCidades;
        }

        internal List<CidadeDTO> ConsultarCidadesByEstado(int idEstado)
        {
            this.Mensagem = "";
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadesByEstado(idEstado);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeDAO.GetInstance().Mensagem;
            }
            return lstCidades;
        }
        
        internal CidadeDTO ConsultarCidadeById(int idCidade)
        {
            this.Mensagem = "";
            CidadeDTO cidade = CidadeDAO.GetInstance().ConsultarCidadeById(idCidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeDAO.GetInstance().Mensagem;
            }
            return cidade;
        }

        internal void AtualizarCidade(CidadeDTO cidade)
        {
            this.Mensagem = "";
            CidadeDAO.GetInstance().AtualizarCidade(cidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeDAO.GetInstance().Mensagem;
            }
        }

        internal void ExcluirCidade(int idCidade)
        {
            this.Mensagem = "";
            CidadeDAO.GetInstance().ExlcuirCidade(idCidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeDAO.GetInstance().Mensagem;
            }
        }

    }
}
