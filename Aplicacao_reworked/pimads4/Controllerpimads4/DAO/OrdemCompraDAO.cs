using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraDAO
    {
        public static OrdemCompraDAO instance;
        private String mensagem;

        private OrdemCompraDAO() { }

        public string Mensagem { get => mensagem; set => mensagem = value; }

        public static OrdemCompraDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraDAO();
            }
            return instance;
        }

        internal int CadastrarOrdemCompra(OrdemCompraDTO ordemCompra)
        {
            this.Mensagem = "";
            int id_OrdemCompra=0;

            string sqlText = "insert into OrdemCompra(valorTotal,dtDigitacao,tpStatus,fk_idUsuario_Usuarios,fk_idPessoa_Pessoas)" +
            " OUTPUT INSERTED.idOrdemCompra VALUES(@valorTotal,@dtDigitacao,@tpStatus,@fk_idUsuario_Usuarios,@fk_idPessoa_Pessoas)";

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());
            cmd.Parameters.AddWithValue("@valorTotal", ordemCompra.ValorTotal);
            cmd.Parameters.AddWithValue("@dtDigitacao", ordemCompra.DtDigitacao);
            cmd.Parameters.AddWithValue("@tpStatus", ordemCompra.TpStatus);
            cmd.Parameters.AddWithValue("@fk_idUsuario_Usuarios", ordemCompra.Usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@fk_idPessoa_Pessoas", ordemCompra.Pessoa.IdPessoa);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                id_OrdemCompra = (int)cmd.ExecuteScalar();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
               ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR ORDEM DE COMPRA";
            }

            return id_OrdemCompra;
        }

        internal List<OrdemCompraDTO> ConsultarOrdemCompraTodos()
        {
            this.Mensagem = "";
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
                    mObj.DtDigitacao = DateTime.Parse(dr["dtDigitacao"].ToString()).ToString("dd/MM/yyyy");
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
                this.Mensagem = "FALHA AO CONSULTAR ORDEM DE COMPRA";
            }
            return lstObj;
        }

        internal List<OrdemCompraDTO> ConsultarOrdemCompraEmitida(string mDt_Inicio, string mDt_Final,int idPessoa)
        {
            this.Mensagem = "";
            String sqlText = "SELECT * FROM OrdemCompra JOIN Pessoas on Pessoas.idPessoa = OrdemCompra.fk_idPessoa_Pessoas";

            if (mDt_Inicio != "" && idPessoa>0)
            {
                sqlText = sqlText + " WHERE(dtDigitacao BETWEEN " + 
                    "'" + mDt_Inicio + "' AND " +
                    "'" + mDt_Final + "') AND " +
                    "fk_idPessoa_Pessoas = " + idPessoa + "";
            }
            else if (mDt_Inicio =="" && idPessoa>0)
            {
                sqlText = sqlText + " WHERE fk_idPessoa_Pessoas = " + idPessoa  + "";
            }
            else if (mDt_Inicio !="" && idPessoa==0)
            {
                sqlText = sqlText + " WHERE(dtDigitacao BETWEEN " +
                    "'" + mDt_Inicio + "' AND " +
                    "'" + mDt_Final + "' )";
            }
                     
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
                    mObj.DtDigitacao = DateTime.Parse(dr["dtDigitacao"].ToString()).ToString("dd/MM/yyyy");
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
                this.Mensagem = "FALHA AO CONSULTAR ORDEM DE COMPRA";
            }
            return lstObj;
        }

    }
}
