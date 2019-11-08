using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class PedidoVendaDTO
    {
        private int idPedido;
        private string dtDigitacao;
        private double valorTotal;
        private string tpPagamento;
        private string tpStatus;
        private PessoaDTO pessoa;
        private UsuarioDTO usuario;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string DtDigitacao { get => dtDigitacao; set => dtDigitacao = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string TpPagamento { get => tpPagamento; set => tpPagamento = value; }
        public string TpStatus { get => tpStatus; set => tpStatus = value; }
        public PessoaDTO Pessoa { get => pessoa; set => pessoa = value; }
        public UsuarioDTO Usuario { get => usuario; set => usuario = value; }

        public PedidoVendaDTO()
        {
            Pessoa = new PessoaDTO();
            Usuario = new UsuarioDTO();
        }
    }
}
