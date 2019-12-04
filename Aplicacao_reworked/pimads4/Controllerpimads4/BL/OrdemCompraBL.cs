using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class OrdemCompraBL
    {
        public static OrdemCompraBL instance;
        public string mensagem;

        private OrdemCompraBL() { }

        public static OrdemCompraBL GetInstance()
        {
            if (instance== null)
            {
                instance = new OrdemCompraBL();
            }
            return instance;
        }

        internal void CadastrarOrdemCompra(OrdemCompraDTO ordemCompra, List<OrdemCompraProdutoDTO> listaOcProduto)
        {
            this.mensagem = "";
            int id_OrdemCompra = 0;

            id_OrdemCompra = OrdemCompraDAO.GetInstance().CadastrarOrdemCompra(ordemCompra);
            if (OrdemCompraDAO.GetInstance().Mensagem != "")
            {
                this.mensagem = OrdemCompraDAO.GetInstance().Mensagem;
                return;
            }

            OrdemCompraProdutoDAO.GetInstance().CadastrarProdutoOrdemCompra(listaOcProduto, id_OrdemCompra);
            if (OrdemCompraProdutoDAO.GetInstance().Mensagem!="")
            {
                this.mensagem = OrdemCompraProdutoDAO.GetInstance().Mensagem;
                return;
            }

            ProdutoDAO.GetInstance().AtualizarProdutoQuantidadeOc(listaOcProduto);
            if (ProdutoDAO.GetInstance().Mensagem!="")
            {
                this.mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
        }
        
        internal List<OrdemCompraDTO> ConsultarOrdemCompraTodos()
        {
            this.mensagem = "";

            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
            listaOrdemCompra = OrdemCompraDAO.GetInstance().ConsultarOrdemCompraTodos();
            if (OrdemCompraDAO.GetInstance().Mensagem != "")
            {
                this.mensagem = OrdemCompraDAO.GetInstance().Mensagem;
            }
            
            return listaOrdemCompra;
        }

        internal List<OrdemCompraDTO> ConsultarOrdemCompraEmitida(string mDt_Inicio, string mDt_Final, int idPessoa)
        {
            this.mensagem = "";
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
           
            if (mDt_Inicio =="" && mDt_Final !="")
            {
                this.mensagem = "POR FAVOR INFORME UMA DATA INICIAL";
            }
            else
            {
                if (mDt_Inicio != "" && mDt_Final == "")
                {
                    mDt_Final = mDt_Inicio;
                }
                listaOrdemCompra = OrdemCompraDAO.GetInstance().ConsultarOrdemCompraEmitida(mDt_Inicio, mDt_Final, idPessoa);
                if (OrdemCompraDAO.GetInstance().Mensagem != "")
                {
                    this.mensagem = OrdemCompraDAO.GetInstance().Mensagem;
                }
            }

            return listaOrdemCompra;
        }
    }
}
