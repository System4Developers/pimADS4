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
            }
        }

        internal List<CidadeDTO> ConsultarCidades()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadeTodos();
            return lstCidades;
        }

        internal List<CidadeDTO> ConsultarCidadesByEstado(int idEstado)
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeDAO.GetInstance().ConsultarCidadesByEstado(idEstado);
            return lstCidades;
        }
        
        internal CidadeDTO ConsultarCidadeById(int idCidade)
        {
            CidadeDTO cidade = CidadeDAO.GetInstance().ConsultarCidadeById(idCidade);
            return cidade;
        }

        internal void AtualizarCidade(CidadeDTO cidade)
        {
            CidadeDAO.GetInstance().AtualizarCidade(cidade);
        }

        internal void ExcluirCidade(int idCidade)
        {
            CidadeDAO.GetInstance().ExlcuirCidade(idCidade);
        }

    }
}
