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

        internal List<PedidoVendaProdutoDTO> ConsultarProdutosPorIdPedidoVenda(int id_PedidoVenda)
        {
            this.mensagem = "";

            String sqlText = string.Format("select * from PedidoVendaProduto join Produtos on produtos.idProduto = PedidoVendaProduto.fk_idProduto_Produtos " +
                "where fk_idPedidoVenda_PedidoVenda = {0}", id_PedidoVenda);
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            PedidoVendaProdutoDTO mObj = null;
            List<PedidoVendaProdutoDTO> lstObj = new List<PedidoVendaProdutoDTO>();

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new PedidoVendaProdutoDTO();
                    mObj.IdPedItem = Convert.ToInt32(dr["idPedidoVendaProduto"]);
                    mObj.VlrUnit = Convert.ToDouble(dr["vlrUnit"]);
                    mObj.Quantidade = Convert.ToInt32(dr["quantidade"]);
                    mObj.PedidoVenda.IdPedido = Convert.ToInt32(dr["fk_idPedidoVenda_PedidoVenda"]);
                    mObj.Produto.IdProduto = Convert.ToInt32(dr["fk_idProduto_Produtos"]);
                    mObj.Produto.DsProduto = dr["dsProduto"].ToString();

                    lstObj.Add(mObj);

                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.mensagem = ex.Message + " - " + cmd.CommandText + " " + ex;
            }
            return lstObj;
        }

    }
}
