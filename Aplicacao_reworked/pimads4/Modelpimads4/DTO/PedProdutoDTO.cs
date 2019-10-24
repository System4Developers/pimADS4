using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class PedProdutoDTO
    {
        private int idPedItem;
        private int quantidade;
        private Double vlrUnit;
        private ProdutoDTO produto;
        private PedidoDTO pedido;

        public int IdPedItem { get => idPedItem; set => idPedItem = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double VlrUnit { get => vlrUnit; set => vlrUnit = value; }
        public ProdutoDTO Produto { get => produto; set => produto = value; }
        public PedidoDTO Pedido { get => pedido; set => pedido = value; }

        public PedProdutoDTO()
        {
            Produto = new ProdutoDTO();
            Pedido = new PedidoDTO();
        }

    }
}
