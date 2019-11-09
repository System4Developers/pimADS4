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
    public class FabricanteDAO
    {
        private static FabricanteDAO instance;

        private FabricanteDAO() { }

        public static FabricanteDAO GetInstance()
        {
            if(instance == null)
            {
                instance = new FabricanteDAO();
            }
            return instance;
        }
        
        internal void CadastrarFabricante(FabricanteDTO mObj)
        {

            SqlCommand cmd = new SqlCommand("sp_CadastrarFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nmFabricante", mObj.NmFabricante);

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
        
        internal List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            String sqlText = "SELECT * FROM Fabricantes";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<FabricanteDTO> lstObj = new List<FabricanteDTO>();
            FabricanteDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new FabricanteDTO();
                    mObj.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    mObj.NmFabricante = dr["nmFabricante"].ToString();

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
        
        internal FabricanteDTO ConsultarFabricanteById(int idAtributo)
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarFabricanteById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idAtributo);

            FabricanteDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mObj = new FabricanteDTO();
                    mObj.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    mObj.NmFabricante = dr["nmFabricante"].ToString();
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
        
        internal void AtualizarFabricante(FabricanteDTO mObj)
        {
           
            SqlCommand cmd = new SqlCommand("sp_AtualizarFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", mObj.IdFabricante);
            cmd.Parameters.AddWithValue("@nmFabricante", mObj.NmFabricante);

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
        
        internal void ExcluirFabricante(int idAtributo)
        {
  
            SqlCommand cmd = new SqlCommand("sp_ExcluirFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idAtributo);

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
