﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class ProdutoDTO
    {
        private int idProduto;
        private string dsProduto;
        private double valorEntrada;
        private double valorCusto;
        private UnidadeDTO unidade;
        private FabricanteDTO fabricante;

        public int IdProduto { get => idProduto; set => idProduto = value; }
        public string DsProduto { get => dsProduto; set => dsProduto = value; }
        public double ValorEntrada { get => valorEntrada; set => valorEntrada = value; }
        public double ValorCusto { get => valorCusto; set => valorCusto = value; }
        public UnidadeDTO Unidade { get => unidade; set => unidade = value; }
        public FabricanteDTO Fabricante { get => fabricante; set => fabricante = value; }
        
        public ProdutoDTO()
        {
            Unidade = new UnidadeDTO();
            Fabricante = new FabricanteDTO();
        }


    }
}
