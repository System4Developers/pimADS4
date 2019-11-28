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
        private string menasgem;

        public string Menasgem { get => menasgem; set => menasgem = value; }

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
            if (cidade.NmCidade != "")
            {
                CidadeDAO.GetInstance().CadastrarCidade(cidade);
                if (CidadeDAO.GetInstance().Mensagem!="")
                {
                    this.Menasgem = CidadeDAO.GetInstance().Mensagem;
                }
            }
        }

        internal List<CidadeDTO> ConsultarCidades()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadeTodos();
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Menasgem = CidadeDAO.GetInstance().Mensagem;
            }
            return lstCidades;
        }

        internal List<CidadeDTO> ConsultarCidadesByEstado(int idEstado)
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadesByEstado(idEstado);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Menasgem = CidadeDAO.GetInstance().Mensagem;
            }
            return lstCidades;
        }
        
        internal CidadeDTO ConsultarCidadeById(int idCidade)
        {
            CidadeDTO cidade = CidadeDAO.GetInstance().ConsultarCidadeById(idCidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Menasgem = CidadeDAO.GetInstance().Mensagem;
            }
            return cidade;
        }

        internal void AtualizarCidade(CidadeDTO cidade)
        {
            CidadeDAO.GetInstance().AtualizarCidade(cidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Menasgem = CidadeDAO.GetInstance().Mensagem;
            }
        }

        internal void ExcluirCidade(int idCidade)
        {
            CidadeDAO.GetInstance().ExlcuirCidade(idCidade);
            if (CidadeDAO.GetInstance().Mensagem != "")
            {
                this.Menasgem = CidadeDAO.GetInstance().Mensagem;
            }
        }

    }
}
