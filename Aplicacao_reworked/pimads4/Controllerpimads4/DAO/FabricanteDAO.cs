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
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_CadastrarFabricante", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nmFabricante", fabricante.NmFabricante);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }
        
        internal List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "SELECT * FROM Fabricantes";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            FabricanteDTO fabricante = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fabricante = new FabricanteDTO();
                    fabricante.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    fabricante.NmFabricante = dr["nmFabricante"].ToString();

                    lstFabricantes.Add(fabricante);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstFabricantes;
        }
        
        internal FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_ConsultarFabricanteById", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idFabricante);

            FabricanteDTO fabricante = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fabricante = new FabricanteDTO();
                    fabricante.IdFabricante = Convert.ToInt32(dr["idFabricante"]);
                    fabricante.NmFabricante = dr["nmFabricante"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);

            }
            return fabricante;
        }
        
        internal void AtualizarFabricante(FabricanteDTO fabricante)
        {
            string connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_AtualizarFabricante", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", fabricante.IdFabricante);
            cmd.Parameters.AddWithValue("@nmFabricante", fabricante.NmFabricante);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
             throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }
        
        internal void ExcluirFabricante(int idFabricante)
        {
            string connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("sp_ExcluirFabricante", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFabricante", idFabricante);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }

        }

    }
}
