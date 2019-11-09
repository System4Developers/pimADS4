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
            if (unidade.DsUnidade !="")
            {
                UnidadeDAO.GetInstance().CadastrarUnidade(unidade);
            }

        }

        internal List<UnidadeDTO> ConsultarUnidades()
        {
            List<UnidadeDTO> lstUnidades = new List<UnidadeDTO>();
            lstUnidades = UnidadeDAO.GetInstance().ConsultarUnidadeTodos();
            return lstUnidades;
        }

        internal UnidadeDTO ConsultarUnidadeById(int idUnidade)
        {
            UnidadeDTO unidade = UnidadeDAO.GetInstance().ConsultarUnidadeById(idUnidade);
            return unidade;
        }

        internal void AtualizarUnidade(UnidadeDTO unidade)
        {
            UnidadeDAO.GetInstance().AtualizarUnidade(unidade);
        }

        internal void ExcluirUnidade(int idUnidade)
        {
            UnidadeDAO.GetInstance().ExlcuirUnidade(idUnidade);
        }
 
    }
}
