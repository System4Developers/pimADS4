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

        private BairroDAO() { }

        public static BairroDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new BairroDAO();
            }

            return instance;
        }


        
        internal List<BairroDTO> ConsultarBairrosTodos()
        {
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
                 throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstBairros;
        }
    }
}
