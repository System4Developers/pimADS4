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
        public string mensagem;

        private OrdemCompraProdutoDAO() { }

        public static OrdemCompraProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraProdutoDAO();
            }
            return instance;
        }

        internal List<OrdemCompraProdutoDTO> ConsultarProdutosPorIdOrdemCompra(int id_OrdemCompra)
        {
            this.mensagem = "";

            String sqlText =string.Format("select * from OrdemCompraProduto join Produtos on produtos.idProduto = OrdemCompraProduto.fk_idProduto_Produtos " +
                "where fk_idOrdemCompra_OrdemCompra = {0}",id_OrdemCompra);
            SqlCommand cmd = new SqlCommand(sqlText,ConexaoDAO.GetInstance().Conexao());

            OrdemCompraProdutoDTO mObj = null;
            List<OrdemCompraProdutoDTO> lstObj = new List<OrdemCompraProdutoDTO>();

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    mObj = new OrdemCompraProdutoDTO();
                    mObj.IdOcProduto = Convert.ToInt32(dr["idOcProduto"]);
                    mObj.VlrUnit = Convert.ToDouble(dr["vlrUnit"]);
                    mObj.Quantidade = Convert.ToInt32(dr["quantidade"]);
                    mObj.OrdemCompra.IdOrdemCompra = Convert.ToInt32(dr["fk_idOrdemCompra_OrdemCompra"]);
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


        internal void CadastrarProdutoOrdemCompra(List<OrdemCompraProdutoDTO> listaProdutos, int id_OrdemCompra)
        {
            this.mensagem = "";
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
                    this.mensagem = ex.Message + " - " + cmd.CommandText + " " + ex;
                }
            }
            ConexaoDAO.GetInstance().Desconectar();
        }
    }
}
