using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class OrdemCompraDTO
    {
        private int idOrdemCompra;
        private Double valorTotal;
        private String dtDigitacao;
        private String tpStatus;
        UsuarioDTO usuario;
        PessoaDTO pessoa;

        public int IdOrdemCompra { get => idOrdemCompra; set => idOrdemCompra = value; }
        public double ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string DtDigitacao { get => dtDigitacao; set => dtDigitacao = value; }
        public string TpStatus { get => tpStatus; set => tpStatus = value; }
        public UsuarioDTO Usuario { get => usuario; set => usuario = value; }
        public PessoaDTO Pessoa { get => pessoa; set => pessoa = value; }

        public OrdemCompraDTO()
        {
            Usuario = new UsuarioDTO();
            Pessoa = new PessoaDTO();
        }
    }
}
