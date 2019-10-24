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
        private string dsObs;
        private Double subTotal;
        private int fk_idPedido_pedido;
        private int fk_idProduto_produto;

        public int IdPedItem { get => idPedItem; set => idPedItem = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double VlrUnit { get => vlrUnit; set => vlrUnit = value; }
        public string DsObs { get => dsObs; set => dsObs = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }
        public int Fk_idPedido_pedido { get => fk_idPedido_pedido; set => fk_idPedido_pedido = value; }
        public int Fk_idProduto_produto { get => fk_idProduto_produto; set => fk_idProduto_produto = value; }
    }
}
