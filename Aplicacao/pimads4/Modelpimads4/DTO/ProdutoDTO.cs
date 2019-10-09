using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class ProdutoDTO
    {
        private int idProduto;
        private string codAlter;
        private string dsProduto;
        private double valorEntrada;
        private int fk_idFabricante_fabricante;
        private int fk_idUnidade_unidade;

        public int IdProduto { get => idProduto; set => idProduto = value; }
        public string CodAlter { get => codAlter; set => codAlter = value; }
        public string DsProduto { get => dsProduto; set => dsProduto = value; }
        public double ValorEntrada { get => valorEntrada; set => valorEntrada = value; }
        public int Fk_idFabricante_fabricante { get => fk_idFabricante_fabricante; set => fk_idFabricante_fabricante = value; }
        public int Fk_idUnidade_unidade { get => fk_idUnidade_unidade; set => fk_idUnidade_unidade = value; }
    }
}
