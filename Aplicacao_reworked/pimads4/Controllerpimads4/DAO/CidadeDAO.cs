using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class CidadeDAO
    {
        private static CidadeDAO instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private CidadeDAO() { }

        public static CidadeDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new CidadeDAO();
            }
            return instance;
        }

        internal void CadastrarCidade(CidadeDTO mObj)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_CadastrarCidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nmCidade", mObj.NmCidade);
            cmd.Parameters.AddWithValue("@codIBGE", mObj.CodIbge);
            cmd.Parameters.AddWithValue("@fk_idEstado_Estados", mObj.Estado.IdEstado);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR CIDADE";
            }

        }

        internal List<CidadeDTO> ConsultarCidadeTodos()
        {
            this.Mensagem = "";
            String sqlText = "SELECT * FROM Cidades JOIN Estados ON Cidades.fk_idEstado_Estados = Estados.idEstado";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<CidadeDTO> lstObj = new List<CidadeDTO>();
            CidadeDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new CidadeDTO();
                    mObj.IdCidade = Convert.ToInt32(dr["idCidade"]);
                    mObj.NmCidade = dr["nmCidade"].ToString();
                    mObj.CodIbge = dr["codIBGE"].ToString();
                    mObj.Estado.IdEstado = Convert.ToInt32(dr["fk_idEstado_Estados"]);
                    mObj.Estado.DsSigla = dr["dsSigla"].ToString();

                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR CIDADES";
            }
            return lstObj;
        }

        internal List<CidadeDTO> ConsultarCidadeByNm(string nmCidade)
        {
            this.Mensagem = "";
            List<CidadeDTO> lstObj = new List<CidadeDTO>();
            CidadeDTO mObj = null;

            String sqlText = "SELECT * FROM Cidades JOIN Estados ON Cidades.fk_idEstado_Estados = Estados.idEstado";
            if (nmCidade !="")
            {
                sqlText += " WHERE nmCidade like '%" + nmCidade + "%'";
            }

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new CidadeDTO();
                    mObj.IdCidade = Convert.ToInt32(dr["idCidade"]);
                    mObj.NmCidade = dr["nmCidade"].ToString();
                    mObj.CodIbge = dr["codIBGE"].ToString();
                    mObj.Estado.IdEstado = Convert.ToInt32(dr["fk_idEstado_Estados"]);
                    mObj.Estado.DsSigla = dr["dsSigla"].ToString();

                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR CIDADES";
            }
            return lstObj;
        }

        internal CidadeDTO ConsultarCidadeById(int idAtributo)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_ConsultarCidadeById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCidade", idAtributo);

            CidadeDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mObj = new CidadeDTO();
                    mObj.IdCidade = Convert.ToInt32(dr["idCidade"]);
                    mObj.NmCidade = dr["nmCidade"].ToString();
                    mObj.CodIbge = dr["codIBGE"].ToString();
                    mObj.Estado.IdEstado = Convert.ToInt32(dr["fk_idEstado_Estados"]);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR CIDADE ID: " + idAtributo;
            }
            return mObj;
        }

        internal List<CidadeDTO> ConsultarCidadesByEstado(int idAtributo)
        {
            this.Mensagem = "";

            String sqlText = "SELECT * FROM Cidades JOIN Estados ON Cidades.fk_idEstado_Estados = Estados.idEstado" +
                " WHERE idEstado=" + 
                "'"+ idAtributo +"'";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<CidadeDTO> lstObj = new List<CidadeDTO>();
            CidadeDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new CidadeDTO();
                    mObj.IdCidade = Convert.ToInt32(dr["idCidade"]);
                    mObj.NmCidade = dr["nmCidade"].ToString();
                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR CIDADE POR ESTADO ID: " + idAtributo;
            }
            return lstObj;
        }


        internal void AtualizarCidade(CidadeDTO mObj)
        {
            SqlCommand cmd = new SqlCommand("sp_AtualizarCidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCidade", mObj.IdCidade);
            cmd.Parameters.AddWithValue("@nmCidade", mObj.NmCidade);
            cmd.Parameters.AddWithValue("@codIBGE", mObj.CodIbge);
            cmd.Parameters.AddWithValue("@fk_idEstado_Estados", mObj.Estado.IdEstado);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO ATUALIZAR DADOS DE CIDADE";
            }

        }

        internal void ExlcuirCidade(int idAtributo)
        {
            SqlCommand cmd = new SqlCommand("sp_ExcluirCidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCidade", idAtributo);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO EXLCUIR CIDADE";
            }

        }

    }
}
