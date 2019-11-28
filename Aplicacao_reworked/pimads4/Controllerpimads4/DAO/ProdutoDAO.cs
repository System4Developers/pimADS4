using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class ProdutoDAO
    {
        private static ProdutoDAO instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private ProdutoDAO() { }

        public static ProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new ProdutoDAO();
            }
            return instance;
        }

        internal void CadastrarProduto(ProdutoDTO mObj)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_CadastrarProduto", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dsProduto", mObj.DsProduto);
            cmd.Parameters.AddWithValue("@valorVenda", mObj.ValorVenda);
            cmd.Parameters.AddWithValue("@valorCusto", mObj.ValorCusto);
            cmd.Parameters.AddWithValue("@tpProduto", mObj.TpProduto);
            cmd.Parameters.AddWithValue("@fk_idUnidade_Unidades", mObj.Unidade.IdUnidade);
            cmd.Parameters.AddWithValue("@fk_idFabricante_Fabricantes", mObj.Fabricante.IdFabricante);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR PRODUTO";
            }

        }

        internal List<ProdutoDTO> ConsultarProdutoTodos()
        {
            this.Mensagem = "";

            String sqlText = "select * from Produtos" +
                " join Unidades on Unidades.idUnidade = Produtos.fk_idUnidade_Unidades" +
                " join Fabricantes on Fabricantes.idFabricante = Produtos.fk_idFabricante_Fabricantes";

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<ProdutoDTO> lstObj = new List<ProdutoDTO>();
            ProdutoDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new ProdutoDTO();
                    mObj.IdProduto = Convert.ToInt32(dr["idProduto"]);
                    mObj.DsProduto = dr["dsProduto"].ToString();
                    mObj.Quantidade = Convert.ToInt32(dr["quantidade"]);
                    mObj.ValorVenda = Convert.ToDouble(dr["valorVenda"]);
                    mObj.ValorCusto = Convert.ToDouble(dr["valorCusto"]);
                    mObj.TpProduto = dr["tpProduto"].ToString();
                    mObj.Unidade.IdUnidade = Convert.ToInt32(dr["fk_idUnidade_Unidades"]);
                    mObj.Unidade.DsUnidade = dr["dsUnidade"].ToString();
                    mObj.Fabricante.IdFabricante = Convert.ToInt32(dr["fk_idFabricante_Fabricantes"]);
                    mObj.Fabricante.NmFabricante = dr["nmFabricante"].ToString();

                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR PRODUTOS";
            }
            return lstObj;
        }

        internal ProdutoDTO ConsultarProdutoById(int idAtributo)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_ConsultarProdutoById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProduto", idAtributo);

            ProdutoDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mObj = new ProdutoDTO();
                    mObj.IdProduto = Convert.ToInt32(dr["idProduto"]);
                    mObj.DsProduto = dr["dsProduto"].ToString();
                    mObj.ValorVenda = Convert.ToDouble(dr["valorVenda"]);
                    mObj.ValorCusto = Convert.ToDouble(dr["valorCusto"]);
                    mObj.TpProduto = dr["tpProduto"].ToString();
                    mObj.Unidade.IdUnidade = Convert.ToInt32(dr["fk_idUnidade_Unidades"]);
                    mObj.Fabricante.IdFabricante = Convert.ToInt32(dr["fk_idFabricante_Fabricantes"]);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTA PRODUTO ID: " + idAtributo;
            }
            return mObj;
        }

        internal void AtualizarProduto(ProdutoDTO mObj)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_AtualizarProduto", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProduto", mObj.IdProduto);
            cmd.Parameters.AddWithValue("@dsProduto", mObj.DsProduto);
            cmd.Parameters.AddWithValue("@valorVenda", mObj.ValorVenda);
            cmd.Parameters.AddWithValue("@valorCusto", mObj.ValorCusto);
            cmd.Parameters.AddWithValue("@tpProduto", mObj.TpProduto);
            cmd.Parameters.AddWithValue("@fk_idUnidade_Unidades", mObj.Unidade.IdUnidade);
            cmd.Parameters.AddWithValue("@fk_idFabricante_Fabricantes", mObj.Fabricante.IdFabricante);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO ATUALIZAR DADOS DO PRODUTO";
            }

        }

        internal void ExlcuirProduto(int idAtributo)
        {
            SqlCommand cmd = new SqlCommand("sp_ExcluirProduto", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProduto", idAtributo);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO EXCLUIR PRODUTO ID: " + idAtributo;
            }

        }

        internal void AtualizarProdutoQuantidadeOc(List<OrdemCompraProdutoDTO> listaProdutosOc)
        {
            this.Mensagem = "";
            foreach (OrdemCompraProdutoDTO ocProduto in listaProdutosOc)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Produtos SET quantidade = quantidade + @quantidade, valorCusto = @valorCusto where idProduto = @idProduto", ConexaoDAO.GetInstance().Conexao());
                cmd.Parameters.AddWithValue("@quantidade", ocProduto.Quantidade);
                cmd.Parameters.AddWithValue("@idProduto", ocProduto.Produto.IdProduto);
                cmd.Parameters.AddWithValue("@valorCusto", ocProduto.VlrUnit);

                try
                {
                    ConexaoDAO.GetInstance().Conectar();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ConexaoDAO.GetInstance().Desconectar();
                    this.Mensagem = "FALHA AO ATUALIZAR QUANTIDADE DOS PRODUTOS DE ENTRADA";
                }
                ConexaoDAO.GetInstance().Desconectar();
            }

        }

        internal void AtualizarProdutoQuantidadePv(List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";
            foreach (PedidoVendaProdutoDTO pvProduto in listaPvProduto)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Produtos SET quantidade = quantidade - @quantidade where idProduto = @idProduto", ConexaoDAO.GetInstance().Conexao());
                cmd.Parameters.AddWithValue("@quantidade", pvProduto.Quantidade);
                cmd.Parameters.AddWithValue("@idProduto", pvProduto.Produto.IdProduto);

                try
                {
                    ConexaoDAO.GetInstance().Conectar();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ConexaoDAO.GetInstance().Desconectar();
                    this.Mensagem = "FALHA AO ATUALIZAR QUANTIDADE DO PRODUTO DE VENDA";
                }
                ConexaoDAO.GetInstance().Desconectar();
            }

        }

        internal int ConsultarProdutoQuantidade(int Id_Produto)
        {
            this.Mensagem = "";
            int quantidade=0;

            SqlCommand cmd = new SqlCommand("SELECT quantidade from Produtos where idProduto = @idProduto",ConexaoDAO.GetInstance().Conexao());
            cmd.Parameters.AddWithValue("@idProduto", Id_Produto);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    quantidade = Convert.ToInt32(dr["quantidade"]);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR QUANTIDADE DOS PRODUTOS";
            }
            return quantidade;
        }
    }
}
