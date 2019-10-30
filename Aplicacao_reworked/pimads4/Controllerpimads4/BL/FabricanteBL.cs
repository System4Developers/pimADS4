using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class FabricanteBL
    {
        private static FabricanteBL instance;

        private FabricanteBL() { }

        public static FabricanteBL GetInstance()
        {
            if (instance==null)
            {
                instance = new FabricanteBL();
            }

            return instance;
        }

        internal void CadastrarFabricante(FabricanteDTO fabricante)
        {

            if (fabricante.NmFabricante != "")
            {
                FabricanteDAO.GetInstance().CadastrarFabricante(fabricante);
            }
        }
        
        internal List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            lstFabricantes = FabricanteDAO.GetInstance().ConsultarFabricanteTodos();
            return lstFabricantes;
        }
        
        internal FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            FabricanteDTO fabricante = FabricanteDAO.GetInstance().ConsultarFabricanteById(idFabricante);
            return fabricante;
        }
        
        internal void AtualizarFabricante(FabricanteDTO fabricante)
        {
            FabricanteDAO.GetInstance().AtualizarFabricante(fabricante);

        }
        
        internal void ExcluirFabricante(int idFabricante)
        {
            FabricanteDAO.GetInstance().ExcluirFabricante(idFabricante);
        }

    }
}
