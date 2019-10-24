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
        private string dtDigitacao;
        private double valorTotal;
        private string formaPagamento;
        private string tpStatus;
        private string formaAquisicao;
        private string tpPedido;
        private PessoaDTO pessoa;
        private UsuarioDTO usuario;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string DtDigitacao { get => dtDigitacao; set => dtDigitacao = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string FormaPagamento { get => formaPagamento; set => formaPagamento = value; }
        public string TpStatus { get => tpStatus; set => tpStatus = value; }
        public string FormaAquisicao { get => formaAquisicao; set => formaAquisicao = value; }
        public string TpPedido { get => tpPedido; set => tpPedido = value; }
        public PessoaDTO Pessoa { get => pessoa; set => pessoa = value; }
        public UsuarioDTO Usuario { get => usuario; set => usuario = value; }

        public PedidoDTO()
        {
            Pessoa = new PessoaDTO();
            Usuario = new UsuarioDTO();
        }

    }
}
