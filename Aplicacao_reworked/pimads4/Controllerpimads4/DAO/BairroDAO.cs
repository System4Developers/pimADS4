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
    public class BairroDAO
    {
        private static BairroDAO instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private BairroDAO() { }

        public static BairroDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new BairroDAO();
            }

            return instance;
        }

        internal void CadastrarBairro(BairroDTO mObj)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_CadastrarBairro", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dsBairro", mObj.DsBairro);
            cmd.Parameters.AddWithValue("@fk_idCidade_Cidades", mObj.Cidade.IdCidade);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR BAIRRO";
            }

        }
        
        internal List<BairroDTO> ConsultarBairrosTodos()
        {
            this.Mensagem = "";

            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "select * from Bairros join Cidades on Bairros.fk_idCidade_Cidades = Cidades.idCidade join Estados on Cidades.fk_idEstado_estados = Estados.idEstado";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<BairroDTO> lstBairros = new List<BairroDTO>();
            BairroDTO bairro = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bairro = new BairroDTO();
                    bairro.IdBairro = Convert.ToInt32(dr["idBairro"]);
                    bairro.DsBairro = dr["dsBairro"].ToString(); 
                    bairro.Cidade.NmCidade = dr["nmCidade"].ToString();
                    bairro.Cidade.Estado.DsSigla = dr["dsSigla"].ToString();
                                       
                    lstBairros.Add(bairro);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                this.Mensagem = "FALHA AO CONSULTAR BAIRROS";
            }
            return lstBairros;
        }

        internal List<BairroDTO> ConsultarBairrosByCidade(int idAtributo)
        {
            this.Mensagem = "";

            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "select * from Bairros Where fk_idCidade_Cidades ="+ "'" + idAtributo + "'";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<BairroDTO> lstBairros = new List<BairroDTO>();
            BairroDTO bairro = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bairro = new BairroDTO();
                    bairro.IdBairro = Convert.ToInt32(dr["idBairro"]);
                    bairro.DsBairro = dr["dsBairro"].ToString();
                    
                    lstBairros.Add(bairro);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                this.Mensagem = "FALHA AO CONSULTAR BAIRRO POR CIDADE ID: " + idAtributo;
            }
            return lstBairros;
        }

        internal BairroDTO ConsultarBairroById(int idAtributo)
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("sp_ConsultarBairroById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBairro", idAtributo);

            BairroDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mObj = new BairroDTO();
                    mObj.IdBairro = Convert.ToInt32(dr["idBairro"]);
                    mObj.DsBairro = dr["dsBairro"].ToString();
                    mObj.Cidade.IdCidade = Convert.ToInt32(dr["fk_idCidade_Cidades"]);
                    mObj.Cidade.Estado.IdEstado = Convert.ToInt32(dr["fk_idEstado_Estados"]);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR BAIRRO POR ID: " + idAtributo;
            }
            return mObj;
        }
        
        internal void AtualizarBairro(BairroDTO mObj)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_AtualizarBairro", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBairro", mObj.IdBairro);
            cmd.Parameters.AddWithValue("@dsBairro", mObj.DsBairro);
            cmd.Parameters.AddWithValue("@fk_idCidade_Cidades", mObj.Cidade.IdCidade);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO ATUALIZAR BAIRRO";
            }

        }
        
        internal void ExlcuirBairro(int idAtributo)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_ExcluirBairro", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBairro", idAtributo);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO EXCLUIR BAIRRO";
            }

        }

    }
}
