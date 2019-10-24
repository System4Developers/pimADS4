using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class EstoqueDTO
    {

        private ProdutoDTO produto;
        private double qtdDisponivel;

        public ProdutoDTO Produto { get => produto; set => produto = value; }
        public double QtdDisponivel { get => qtdDisponivel; set => qtdDisponivel = value; }
    }
}
