using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class PedidoDTO
    {
        private int idPedido;
        private int numPedido;
        private string formaPagamento;
	    private string tipoStatus;
        private string dtDigitacao;
        private double valorTotal;
        private int fk_idCliente_cliente;
        private int fk_idUsuario_usuario;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int NumPedido { get => numPedido; set => numPedido = value; }
        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
        public string TipoStatus { get => tipoStatus; set => tipoStatus = value; }
        public string DtDigitacao { get => dtDigitacao; set => dtDigitacao = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }
        public int Fk_idCliente_cliente { get => fk_idCliente_cliente; set => fk_idCliente_cliente = value; }
        public int Fk_idUsuario_usuario { get => fk_idUsuario_usuario; set => fk_idUsuario_usuario = value; }

    }
}
