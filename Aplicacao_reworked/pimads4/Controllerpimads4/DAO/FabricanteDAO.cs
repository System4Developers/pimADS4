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
        
        internal void CadastrarFabricante(FabricanteDTO fabricante)
        {

            SqlCommand cmd = new SqlCommand("sp_CadastrarFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nmFabricante", fabricante.NmFabricante);

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

            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            FabricanteDTO fabricante = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fabricante = new FabricanteDTO();
                    fabricante.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    fabricante.NmFabricante = dr["nmFabricante"].ToString();

                    lstFabricantes.Add(fabricante);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstFabricantes;
        }
        
        internal FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarFabricanteById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idFabricante);

            FabricanteDTO fabricante = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fabricante = new FabricanteDTO();
                    fabricante.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    fabricante.NmFabricante = dr["nmFabricante"].ToString();
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);

            }
            return fabricante;
        }
        
        internal void AtualizarFabricante(FabricanteDTO fabricante)
        {
           
            SqlCommand cmd = new SqlCommand("sp_AtualizarFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", fabricante.IdFabricante);
            cmd.Parameters.AddWithValue("@nmFabricante", fabricante.NmFabricante);

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
        
        internal void ExcluirFabricante(int idFabricante)
        {
  
            SqlCommand cmd = new SqlCommand("sp_ExcluirFabricante", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idFabricante);

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
