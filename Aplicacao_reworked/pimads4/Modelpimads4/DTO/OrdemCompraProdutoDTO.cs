using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class OrdemCompraProdutoDTO
    {
        private int idOcProduto;
        private Double vlrUnit;
        private int quantidade;
        OrdemCompraDTO ordemCompra;
        ProdutoDTO produto;

        public int IdOcProduto { get => idOcProduto; set => idOcProduto = value; }
        public double VlrUnit { get => vlrUnit; set => vlrUnit = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public OrdemCompraDTO OrdemCompra { get => ordemCompra; set => ordemCompra = value; }
        public ProdutoDTO Produto { get => produto; set => produto = value; }

        public OrdemCompraProdutoDTO()
        {
            OrdemCompra = new OrdemCompraDTO();
            Produto = new ProdutoDTO();
        }


    }
}
