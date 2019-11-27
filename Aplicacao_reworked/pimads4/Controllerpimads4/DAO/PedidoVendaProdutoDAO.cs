using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PedidoVendaProdutoDAO
    {
        private static PedidoVendaProdutoDAO instance;
        public String mensagem;

        private PedidoVendaProdutoDAO() { }

        public static PedidoVendaProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new PedidoVendaProdutoDAO();
            }
            return instance;
        }

        internal void CadastrarProdutoPedidoVenda(List<PedidoVendaProdutoDTO> listaPvProduto, int id_PedidoVenda)
        {
            this.mensagem = "";
            foreach (PedidoVendaProdutoDTO pvProduto in listaPvProduto)
            {
                SqlCommand cmd = new SqlCommand("insert into PedidoVendaProduto (vlrUnit,quantidade,desconto,fk_idPedidoVenda_PedidoVenda,fk_idProduto_Produtos)" +
               " VALUES(@vlrUnit,@quantidade,@desconto, @fk_idPedidoVenda_PedidoVenda,@fk_idProduto_Produtos)", ConexaoDAO.GetInstance().Conexao());
                cmd.Parameters.AddWithValue("@vlrUnit", pvProduto.VlrUnit);
                cmd.Parameters.AddWithValue("@quantidade", pvProduto.Quantidade);
                cmd.Parameters.AddWithValue("@desconto", pvProduto.Desconto);
                cmd.Parameters.AddWithValue("@fk_idPedidoVenda_PedidoVenda", id_PedidoVenda);
                cmd.Parameters.AddWithValue("@fk_idProduto_Produtos", pvProduto.Produto.IdProduto);

                try
                {
                    ConexaoDAO.GetInstance().Conectar();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ConexaoDAO.GetInstance().Desconectar();
                    this.mensagem = ex.Message + " - " + cmd.CommandText + " " + ex;
                }
            }
            ConexaoDAO.GetInstance().Desconectar();
        }

    }
}
