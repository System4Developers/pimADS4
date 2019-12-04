using Controllerpimads4.DAO;
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
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PedidoVendaProdutoBL() { }

        public static PedidoVendaProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PedidoVendaProdutoBL();
            }

            return instance;
        }

        internal void VerificarProdutoPv(PedidoVendaProdutoDTO pvProduto, List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";

            foreach (PedidoVendaProdutoDTO pvProd in listaPvProduto)
            {
                if (pvProd.Produto.IdProduto == pvProduto.Produto.IdProduto)
                {
                    this.Mensagem = "PRODUTO ID: " + pvProd.Produto.IdProduto + "\nJÁ ADICIONADO AO PEDIDO DE VENDA";
                    return;
                }
            }

            if (pvProduto.Quantidade <= 0)
            {
                this.Mensagem += "QUANTIDADE DO PRODUTO NÃO PODE SER 0 OU MENOR";
                return;
            }
            if (pvProduto.Produto.Quantidade<= 0)
            {
                this.Mensagem += "QUANTIDADE DO PRODUTO NÃO DISPONÍVEL PARA VENDA \nDISPONIVEL: " + pvProduto.Produto.Quantidade + "";
                return;
            }
            if (pvProduto.VlrUnit <= 0)
            {
                this.Mensagem += "VALOR DO PRODUTO NÃO PODE SER 0 OU MENOR";
                return;
            }
            if (pvProduto.Quantidade > pvProduto.Produto.Quantidade)
            {
                pvProduto.Quantidade = pvProduto.Produto.Quantidade;
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
                catch (Exception)
                {
                    this.Mensagem += "NAO FOI POSSIVEL CALCULAR O VALOR DE DESCONTO";
                }
            }

        }

        internal void PvProdCalcularValorTotal(List<PedidoVendaProdutoDTO> listaPvProduto,PedidoVendaDTO pedidoVenda)
        {
            this.Mensagem = "";
            pedidoVenda.ValorTotal = 0;
            pedidoVenda.ValorTotalDesconto = 0;

            try
            {
                foreach (PedidoVendaProdutoDTO pvProduto in listaPvProduto)
                {
                    pedidoVenda.ValorTotal += pvProduto.VlrSubTotal;
                    pedidoVenda.ValorTotalDesconto += pvProduto.Desconto;
                }
            }
            catch (Exception ex)
            {
                this.Mensagem = "NÃO FOI POSSÍVEL CALCULAR O VALOR TOTAL";
            }
        }

        internal void AdicionarQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.Mensagem = "";
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();

            pvProduto = listaPvProduto[index];

            if (listaPvProduto.Count < 1)
            {
                this.Mensagem = "NENHUM PRODUTO P/ ACRESCENTAR QUANTIDADE";
                return;
            }
            if (pvProduto.Quantidade >= pvProduto.Produto.Quantidade)
            {
                this.Mensagem = "QUANTIDADE MAXIMA ANTIGIDA";
                return;
            }

            pvProduto.Quantidade += 1;
            pvProduto.Desconto += pvProduto.Desconto;
            pvProduto.VlrSubTotal = (pvProduto.Quantidade * pvProduto.VlrUnit) - pvProduto.Desconto;
            listaPvProduto[index] = pvProduto;
        }

        internal void RemoverQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.Mensagem = "";
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();

            if (listaPvProduto.Count > 0)
            {
                pvProduto = listaPvProduto[index];

                if (pvProduto.Quantidade > 1)
                {
                    pvProduto.Quantidade += -1;
                    pvProduto.Desconto = pvProduto.Desconto / 2;

                    pvProduto.VlrSubTotal = (pvProduto.Quantidade * pvProduto.VlrUnit)-pvProduto.Desconto;
                    listaPvProduto[index] = pvProduto;
                }
                else
                {
                    this.Mensagem = "QUANTIDADE MINIMA ATINGIDA 1";
                }
            }
            else
            {
                this.Mensagem = "NENHUM PRODUTO P/ RETIRAR QUANTIDADE";
            }

        }

        internal void CadastrarProdutoPedidoVenda(List<PedidoVendaProdutoDTO> listaPvProduto, int id_PedidoVenda)
        {
            this.Mensagem = "";
            PedidoVendaProdutoDAO.GetInstance().CadastrarProdutoPedidoVenda(listaPvProduto, id_PedidoVenda);
            if (PedidoVendaProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoDAO.GetInstance().Mensagem;
            }
        }

        internal List<PedidoVendaProdutoDTO> ConsultarPedidoPorIdPedidoVenda(int id_PedidoVenda)
        {
            this.Mensagem = "";

            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = PedidoVendaProdutoDAO.GetInstance().ConsultarProdutosPorIdPedidoVenda(id_PedidoVenda);
            if (PedidoVendaProdutoDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoDAO.GetInstance().Mensagem;
            }
            return listaPvProduto;
        }

    }
}
