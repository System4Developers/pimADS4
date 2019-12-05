using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class ProdutoBL
    {
        private static ProdutoBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private ProdutoBL() { }

        public static ProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new ProdutoBL();
            }

            return instance;
        }

        internal void CadastrarProduto(ProdutoDTO produto)
        {
            this.Mensagem = "";

            if (produto.DsProduto == "")
            {
                this.Mensagem = "DESCRICAO DO PRODUTO NAO INFORMADA";
                return;
            }
            if (produto.TpProduto == "")
            {
                this.Mensagem = "TIPO DO PRODUTO NAO INFORMADO";
                return;
            }
            if (produto.Fabricante.IdFabricante <= 0)
            {
                this.Mensagem = "FABRICANTE DO PRODUTO NAO INFORMADO";
                return;
            }
            if (produto.Unidade.IdUnidade <=0)
            {
                this.Mensagem = "UNIDADADE DO PRODUTO NAO INFORMADA";
                return;
            }

            ProdutoDAO.GetInstance().CadastrarProduto(produto);
            if (ProdutoDAO.GetInstance().Mensagem!="")
            {
                this.Mensagem= ProdutoDAO.GetInstance().Mensagem;
            }
            
        }
        internal List<ProdutoDTO> ConsultarProdutos()
        {
            this.Mensagem = "";
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = ProdutoDAO.GetInstance().ConsultarProdutoTodos();
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
            return lstProdutos;
        }
        internal List<ProdutoDTO> ConsultarProdutoByDs(string dsProduto)
        {
            this.Mensagem = "";
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = ProdutoDAO.GetInstance().ConsultarProdutoByDs(dsProduto);
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
            return lstProdutos;
        }

        internal ProdutoDTO ConsultarProdutoById(int idProduto)
        {
            this.Mensagem = "";
            ProdutoDTO produto = ProdutoDAO.GetInstance().ConsultarProdutoById(idProduto);
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
            return produto;
        }
        internal void AtualizarProduto(ProdutoDTO produto)
        {
            this.Mensagem = "";
            if (produto.DsProduto == "")
            {
                this.Mensagem = "DESCRICAO DO PRODUTO NAO INFORMADA";
                return;
            }
            if (produto.TpProduto == "")
            {
                this.Mensagem = "TIPO DO PRODUTO NAO INFORMADO";
                return;
            }
            if (produto.Fabricante.IdFabricante <= 0)
            {
                this.Mensagem = "FABRICANTE DO PRODUTO NAO INFORMADO";
                return;
            }
            if (produto.Unidade.IdUnidade <= 0)
            {
                this.Mensagem = "UNIDADADE DO PRODUTO NAO INFORMADA";
                return;
            }

            ProdutoDAO.GetInstance().AtualizarProduto(produto);
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
        }
        internal void ExcluirProduto(int idProduto)
        {
            this.Mensagem = "";
            ProdutoDAO.GetInstance().ExlcuirProduto(idProduto);
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
        }
        internal void AtualizarProdutoQuantidadeOc(List<OrdemCompraProdutoDTO> listaProdutosOc)
        {
            this.Mensagem = "";
            ProdutoDAO.GetInstance().AtualizarProdutoQuantidadeOc(listaProdutosOc);
            if (ProdutoDAO.GetInstance().Mensagem !="")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
        }
        internal void AtualizarProdutoQuantidadePv(List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";
            ProdutoDAO.GetInstance().AtualizarProdutoQuantidadePv(listaPvProduto);
            if (ProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoDAO.GetInstance().Mensagem;
            }
        }
    }
}
