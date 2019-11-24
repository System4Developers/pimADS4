using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class OrdemCompraProdutoBL
    {
        public static OrdemCompraProdutoBL instance;
        public string mensagem;

        private OrdemCompraProdutoBL() { }


        public static OrdemCompraProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraProdutoBL();
            }
            return instance;
        }

        internal void VerificarProdutoOc(OrdemCompraProdutoDTO produtoOc)
        {
            this.mensagem = "";
            if (produtoOc.Quantidade <= 0)
            {
                this.mensagem += "QUANTIDADE DO PRODUTO NÃO PODE SER 0 OU MENOR \n";
            }
            if (produtoOc.VlrUnit <=0)
            {
                this.mensagem += "VALOR DO PRODUTO NÃO PODE SER 0 OU MENOR";
            }
            else
            {
                produtoOc.SubTotal = produtoOc.Quantidade * produtoOc.VlrUnit;
            }
        }

        internal void AdicionarQuantidadeProdutoOc(List<OrdemCompraProdutoDTO> listaProdutosOc,int index)
        {
            this.mensagem = "";
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();

            if (listaProdutosOc.Count<1)
            {
                this.mensagem = "NENHUM PRODUTO P/ ACRESCENTAR QUANTIDADE";
            }
            else
            {
                ocProduto = listaProdutosOc[index];
                ocProduto.Quantidade += 1;
                ocProduto.SubTotal = ocProduto.Quantidade * ocProduto.VlrUnit;
                listaProdutosOc[index] = ocProduto;
            }
                        
        }

        internal void RemoverQuantidadeProdutoOc(List<OrdemCompraProdutoDTO> listaProdutosOc, int index)
        {
            this.mensagem = "";
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();

            if (listaProdutosOc.Count > 0)
            {
                ocProduto = listaProdutosOc[index];

                if (ocProduto.Quantidade > 1)
                {
                    ocProduto.Quantidade += -1;
                    ocProduto.SubTotal = ocProduto.Quantidade * ocProduto.VlrUnit;
                    listaProdutosOc[index] = ocProduto;
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

        internal double OcProdCalcularValorTotal(List<OrdemCompraProdutoDTO> listaProdutosOc)
        {
            this.mensagem = "";
            Double vlTotal = 0;

            try
            {
                foreach (OrdemCompraProdutoDTO ocProduto in listaProdutosOc)
                {
                    vlTotal += ocProduto.SubTotal;
                }
            }
            catch (Exception ex)
            {
                this.mensagem = "NÃO FOI POSSÍVEL CALCULAR O VALOR TOTAL";
            }
            return vlTotal;
        }

        internal void CadastrarProdutoOrdemCompra(List<OrdemCompraProdutoDTO> listaProdutos,int id_OrdemCompra)
        {
            OrdemCompraProdutoDAO.GetInstance().CadastrarProdutoOrdemCompra(listaProdutos, id_OrdemCompra);
        }

    }
}
