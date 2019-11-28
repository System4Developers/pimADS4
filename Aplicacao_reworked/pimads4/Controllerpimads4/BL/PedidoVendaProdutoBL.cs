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

        internal void PvProdCalcularValorTotal(List<PedidoVendaProdutoDTO> listaPvProduto,PedidoVendaDTO pedidoVenda)
        {
            this.mensagem = "";
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
                this.mensagem = "NÃO FOI POSSÍVEL CALCULAR O VALOR TOTAL";
            }
        }

        internal void AdicionarQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.mensagem = "";
            int quantidade = 0;

            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();

            if (listaPvProduto.Count < 1)
            {
                this.mensagem = "NENHUM PRODUTO P/ ACRESCENTAR QUANTIDADE";
                return;
            }
            
            quantidade = ProdutoDAO.GetInstance().ConsultarProdutoQuantidade(pvProduto.Produto.IdProduto);
            if (ProdutoDAO.GetInstance().mensagem != "")
            {
                this.mensagem = ProdutoDAO.GetInstance().mensagem;
                return;
            }
            pvProduto = listaPvProduto[index];
            pvProduto.Quantidade += 1;

            if (pvProduto.Quantidade > quantidade)
            {
                this.mensagem = "QUANTIDADE MAXIMA ANTIGIDA";
            }

            pvProduto.Desconto += pvProduto.Desconto;
            pvProduto.VlrSubTotal = (pvProduto.Quantidade * pvProduto.VlrUnit) - pvProduto.Desconto;
            listaPvProduto[index] = pvProduto;
        }

        internal void RemoverQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.mensagem = "";
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
                    this.mensagem = "QUANTIDADE MINIMA ATINGIDA 1";
                }
            }
            else
            {
                this.mensagem = "NENHUM PRODUTO P/ RETIRAR QUANTIDADE";
            }

        }

        internal void CadastrarProdutoPedidoVenda(List<PedidoVendaProdutoDTO> listaPvProduto, int id_PedidoVenda)
        {
            this.mensagem = "";
            PedidoVendaProdutoDAO.GetInstance().CadastrarProdutoPedidoVenda(listaPvProduto, id_PedidoVenda);
            if (PedidoVendaProdutoDAO.GetInstance().mensagem != "")
            {
                this.mensagem = PedidoVendaProdutoDAO.GetInstance().mensagem;
            }
        }

        internal List<PedidoVendaProdutoDTO> ConsultarPedidoPorIdPedidoVenda(int id_PedidoVenda)
        {
            this.mensagem = "";

            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = PedidoVendaProdutoDAO.GetInstance().ConsultarProdutosPorIdPedidoVenda(id_PedidoVenda);
            return listaPvProduto;
        }

    }
}
