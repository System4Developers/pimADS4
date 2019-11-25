using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraDAO
    {
        public static OrdemCompraDAO instance;
        public String mensagem;

        private OrdemCompraDAO() { }

        public static OrdemCompraDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraDAO();
            }
            return instance;
        }

        internal int CadastrarPedidoCompra(OrdemCompraDTO ordemCompra)
        {
            this.mensagem = "";
            int id_OrdemCompra=0;
            
            string sqlText = string.Format("insert into OrdemCompra (valorTotal,dtDigitacao,tpStatus,fk_idUsuario_Usuarios,fk_idPessoa_Pessoas)" +
            " OUTPUT INSERTED.idOrdemCompra VALUES({0},'{1}','{2}',{3},{4})",ordemCompra.ValorTotal, ordemCompra.DtDigitacao, ordemCompra.TpStatus,ordemCompra.Usuario.IdUsuario, ordemCompra.Pessoa.IdPessoa);

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                id_OrdemCompra = (int)cmd.ExecuteScalar();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
               ConexaoDAO.GetInstance().Desconectar();
               this.mensagem = ex.Message + " - " + "\n" + cmd.CommandText + "\n" + ex;
            }

            return id_OrdemCompra;
        }

        internal List<OrdemCompraDTO> ConsultarOrdemCompraTodos()
        {
            this.mensagem = "";
            String sqlText = "SELECT * FROM OrdemCompra JOIN Pessoas on Pessoas.idPessoa = OrdemCompra.fk_idPessoa_Pessoas";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<OrdemCompraDTO> lstObj = new List<OrdemCompraDTO>();
            OrdemCompraDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new OrdemCompraDTO();
                    mObj.IdOrdemCompra = Convert.ToInt32(dr["idOrdemCompra"]);
                    mObj.ValorTotal = Convert.ToDouble(dr["valorTotal"]);
                    mObj.DtDigitacao = dr["dtDigitacao"].ToString();
                    mObj.TpStatus = dr["tpStatus"].ToString();
                    mObj.Pessoa.IdPessoa = Convert.ToInt32(dr["idPessoa"]);
                    mObj.Pessoa.NmPessoa = dr["nmPessoa"].ToString();
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
