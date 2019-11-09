using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class UnidadeDAO
    {
        private static UnidadeDAO instance;
        
        private UnidadeDAO() { }

        public static UnidadeDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new UnidadeDAO();
            }
                
            return instance;
        }

        internal void CadastrarUnidade(UnidadeDTO mObj)
        {
            SqlCommand cmd = new SqlCommand("sp_CadastrarUnidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dsUnidade", mObj.DsUnidade);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

        internal List<UnidadeDTO> ConsultarUnidadeTodos()
        {
            String sqlText = "SELECT * FROM Unidades";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<UnidadeDTO> lstObj = new List<UnidadeDTO>();
            UnidadeDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new UnidadeDTO();
                    mObj.IdUnidade = Convert.ToInt32(dr["idUnidade"]);
                    mObj.DsUnidade = dr["dsUnidade"].ToString();

                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstObj;
        }

        internal UnidadeDTO ConsultarUnidadeById(int idAtributo)
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarUnidadeById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUnidade", idAtributo);

            UnidadeDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mObj = new UnidadeDTO();
                    mObj.IdUnidade = Convert.ToInt32(dr["idUnidade"]);
                    mObj.DsUnidade = dr["dsUnidade"].ToString();
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return mObj;
        }

        internal void AtualizarUnidade(UnidadeDTO mObj)
        {
            SqlCommand cmd = new SqlCommand("sp_AtualizarUnidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUnidade", mObj.IdUnidade);
            cmd.Parameters.AddWithValue("@dsUnidade", mObj.DsUnidade);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

        internal void ExlcuirUnidade(int idAtributo)
        {
            SqlCommand cmd = new SqlCommand("sp_ExcluirUnidade", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUnidade", idAtributo);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }



    }
}
