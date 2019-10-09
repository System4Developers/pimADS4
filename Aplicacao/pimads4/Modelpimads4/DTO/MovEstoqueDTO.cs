using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class MovEstoqueDTO
    {
        private int idMovimentacao;
        private string dtMov;
        private int quantidade;
        private int operacao;
        private string Obs;
        private int fk_idProduto_produto;
        private int fk_idUsuario_usuario;

        public int IdMovimentacao { get => idMovimentacao; set => idMovimentacao = value; }
        public string DtMov { get => dtMov; set => dtMov = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int Operacao { get => operacao; set => operacao = value; }
        public string Obs1 { get => Obs; set => Obs = value; }
        public int Fk_idProduto_produto { get => fk_idProduto_produto; set => fk_idProduto_produto = value; }
        public int Fk_idUsuario_usuario { get => fk_idUsuario_usuario; set => fk_idUsuario_usuario = value; }
    }
}
