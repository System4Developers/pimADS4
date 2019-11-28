using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedidoVendaBL
    {
        private static PedidoVendaBL instance;
        private String mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PedidoVendaBL() { }

        public static PedidoVendaBL GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoVendaBL();
            }
            return instance;
        }

        internal List<PedidoVendaDTO> ConsultarPedidoVendaTodos()
        {
            this.Mensagem = "";
            List<PedidoVendaDTO> lstPedidos = new List<PedidoVendaDTO>();
            lstPedidos = PedidoVendaDAO.GetInstance().ConsultarPedidoVendaTodos();
            if (PedidoVendaDAO.GetInstance().Mensagem!="")
            {
                this.Mensagem = PedidoVendaDAO.GetInstance().Mensagem;
            }
            return lstPedidos;
        }

        internal void CadastrarPedidoVenda(PedidoVendaDTO pedidoVenda, List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";
            int id_PedidoVenda = 0;

            id_PedidoVenda = PedidoVendaDAO.GetInstance().CadastrarPedidoVenda(pedidoVenda);
            if (PedidoVendaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaDAO.GetInstance().Mensagem;
            }
            else
            {
                PedidoVendaProdutoDAO.GetInstance().CadastrarProdutoPedidoVenda(listaPvProduto, id_PedidoVenda);
                if (PedidoVendaProdutoDAO.GetInstance().Mensagem!="")
                {
                    this.Mensagem = PedidoVendaProdutoDAO.GetInstance().Mensagem;
                }
            }

        }
    }
}
