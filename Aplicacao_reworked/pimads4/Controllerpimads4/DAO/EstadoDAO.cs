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
    public class EstadoDAO
    {
        private static EstadoDAO instance;

        private EstadoDAO() { }

        public static EstadoDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new EstadoDAO();
            }
            return instance;
        }

        internal List<EstadoDTO> ConsultarEstadosTodos()
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "select * from Estados";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<EstadoDTO> lstEstados = new List<EstadoDTO>();
            EstadoDTO estado = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    estado.IdEstado = Convert.ToInt32(dr["idEstado"]);
                    estado.NmEstado = dr["nmEstado"].ToString();
                    estado.CodIbge = dr["codIBGE"].ToString();
                    estado.DsSigla = dr["dsSigla"].ToString();


                    lstEstados.Add(estado);
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
            return lstEstados;
        }

    }
}
