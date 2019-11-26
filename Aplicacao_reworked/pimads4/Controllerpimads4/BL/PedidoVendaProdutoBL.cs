using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedidoVendaProdutoBL
    {
        private static PedidoVendaProdutoBL instance;
        public string mensagem;

        private PedidoVendaProdutoBL() { }

        public static PedidoVendaProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PedidoVendaProdutoBL();
            }

            return instance;
        }

        internal void VerificarProdutoPv(PedidoVendaProdutoDTO pvProduto)
        {
            this.mensagem = "";
            if (pvProduto.Quantidade <= 0)
            {
                this.mensagem += "QUANTIDADE DO PRODUTO NÃO PODE SER 0 OU MENOR";
                return;
            }
            if (pvProduto.VlrUnit <= 0)
            {
                this.mensagem += "VALOR DO PRODUTO NÃO PODE SER 0 OU MENOR";
                return;
            }

            pvProduto.VlrSubTotal = pvProduto.Quantidade * pvProduto.VlrUnit;
            pvProduto.Desconto = 0;

            if (pvProduto.VlrDesconto != "")
            {
                try
                {
                    Double vlDesconto = Convert.ToDouble(pvProduto.VlrDesconto) / 100;
                    pvProduto.Desconto = pvProduto.VlrSubTotal * vlDesconto;
                    pvProduto.VlrSubTotal = pvProduto.VlrSubTotal - pvProduto.Desconto;
                }
                catch (Exception ex)
                {
                    this.mensagem += "NAO FOI POSSIVEL CALCULAR O VALOR DE DESCONTO";
                }
            }

        }

        internal double PvProdCalcularValorTotal(List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.mensagem = "";
            Double vlTotal = 0;

            try
            {
                foreach (PedidoVendaProdutoDTO pvProduto in listaPvProduto)
                {
                    vlTotal += pvProduto.VlrSubTotal;
                }
            }
            catch (Exception ex)
            {
                this.mensagem = "NÃO FOI POSSÍVEL CALCULAR O VALOR TOTAL";
            }
            return vlTotal;
        }
    }
}
