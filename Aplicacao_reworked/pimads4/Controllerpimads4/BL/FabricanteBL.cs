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
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

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
            this.Mensagem = "";
            if (fabricante.NmFabricante != "")
            {
                FabricanteDAO.GetInstance().CadastrarFabricante(fabricante);
                if (FabricanteDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = FabricanteDAO.GetInstance().Mensagem;
                }
            }
        }
        
        internal List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            this.Mensagem = "";
            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            lstFabricantes = FabricanteDAO.GetInstance().ConsultarFabricanteTodos();
            if (FabricanteDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteDAO.GetInstance().Mensagem;
            }
            return lstFabricantes;
        }
        
        internal FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            this.Mensagem = "";
            FabricanteDTO fabricante = FabricanteDAO.GetInstance().ConsultarFabricanteById(idFabricante);
            if (FabricanteDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteDAO.GetInstance().Mensagem;
            }
            return fabricante;
        }
        
        internal void AtualizarFabricante(FabricanteDTO fabricante)
        {
            this.Mensagem = "";
            FabricanteDAO.GetInstance().AtualizarFabricante(fabricante);
            if (FabricanteDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteDAO.GetInstance().Mensagem;
            }

        }
        
        internal void ExcluirFabricante(int idFabricante)
        {
            this.Mensagem = "";
            FabricanteDAO.GetInstance().ExcluirFabricante(idFabricante);
            if (FabricanteDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteDAO.GetInstance().Mensagem;
            }
        }

    }
}
