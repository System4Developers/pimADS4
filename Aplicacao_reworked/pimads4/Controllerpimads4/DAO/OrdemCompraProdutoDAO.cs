using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraProdutoDAO
    {
        public static OrdemCompraProdutoDAO instance;

        private OrdemCompraProdutoDAO() { }

        public static OrdemCompraProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraProdutoDAO();
            }
            return instance;
        }

        internal void CadastrarProdutoOrdemCompra(List<OrdemCompraProdutoDTO> listaProdutos, int id_OrdemCompra)
        {

            foreach (OrdemCompraProdutoDTO ocProduto in listaProdutos)
            {
                SqlCommand cmd = new SqlCommand("insert into OrdemCompraProduto (vlrUnit,quantidade,fk_idOrdemCompra_OrdemCompra,fk_idProduto_Produtos)" +
               " VALUES(@vlrUnit,@quantidade,@fk_idOrdemCompra_OrdemCompra, @fk_idProduto_Produtos)", ConexaoDAO.GetInstance().Conexao());
                cmd.Parameters.AddWithValue("@vlrUnit", ocProduto.VlrUnit);
                cmd.Parameters.AddWithValue("@quantidade", ocProduto.Quantidade);
                cmd.Parameters.AddWithValue("@fk_idOrdemCompra_OrdemCompra", id_OrdemCompra);
                cmd.Parameters.AddWithValue("@fk_idProduto_Produtos", ocProduto.Produto.IdProduto);

                try
                {
                    ConexaoDAO.GetInstance().Conectar();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ConexaoDAO.GetInstance().Desconectar();
                    throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
                }
            }
            ConexaoDAO.GetInstance().Desconectar();

        }
    }
}
