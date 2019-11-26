using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class PedidoVendaProdutoDTO
    {
        private int idPedidoVendaProduto;
        private int quantidade;
        private Double desconto;
        private Double vlrUnit;
        private ProdutoDTO produto;
        private PedidoVendaDTO pedidoVenda;
        private Double vlrSubTotal;
        private String vlrDesconto;

        public int IdPedItem { get => idPedidoVendaProduto; set => idPedidoVendaProduto = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double VlrUnit { get => vlrUnit; set => vlrUnit = value; }
        public ProdutoDTO Produto { get => produto; set => produto = value; }
        public PedidoVendaDTO PedidoVenda { get => pedidoVenda; set => pedidoVenda = value; }
        public Double Desconto { get => desconto; set => desconto = value; }
        public double VlrSubTotal { get => vlrSubTotal; set => vlrSubTotal = value; }
        public string VlrDesconto { get => vlrDesconto; set => vlrDesconto = value; }

        public PedidoVendaProdutoDTO()
        {
            Produto = new ProdutoDTO();
            PedidoVenda = new PedidoVendaDTO();
        }

    }
}
