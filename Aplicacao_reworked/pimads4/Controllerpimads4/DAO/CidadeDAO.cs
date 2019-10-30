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

        private CidadeDAO() { }

        public static CidadeDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new CidadeDAO();
            }
            return instance;
        }
        
        internal List<CidadeDTO> ConsultarCidadesTodos()
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "select * from Cidades join Estados on Cidades.fk_idEstado_estados = Estados.idEstado";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            CidadeDTO cidade = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cidade = new CidadeDTO();
                    cidade.IdCidade = Convert.ToInt32(dr["idCidade"]);
                    cidade.Nome = dr["nmCidade"].ToString();
                    cidade.CodIbge = dr["codIBGE"].ToString();
                    cidade.Estado.DsSigla = dr["dsSigla"].ToString();


                    lstCidades.Add(cidade);
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
            return lstCidades;
        }
    }
}
