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
            if (produto.DsProduto !="")
            {
                ProdutoDAO.GetInstance().CadastrarProduto(produto);
            }
        }
        internal List<ProdutoDTO> ConsultarProdutos()
        {
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = ProdutoDAO.GetInstance().ConsultarProdutoTodos();
            return lstProdutos;
        }
        internal ProdutoDTO ConsultarProdutoById(int idProduto)
        {
            ProdutoDTO produto = ProdutoDAO.GetInstance().ConsultarProdutoById(idProduto);
            return produto;
        }
        internal void AtualizarProduto(ProdutoDTO produto)
        {
            ProdutoDAO.GetInstance().AtualizarProduto(produto);
        }
        internal void ExcluirProduto(int idProduto)
        {
            ProdutoDAO.GetInstance().ExlcuirProduto(idProduto);
        }

    }
}
