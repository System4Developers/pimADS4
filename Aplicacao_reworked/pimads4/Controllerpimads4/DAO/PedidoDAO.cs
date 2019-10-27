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
    public class PedidoDAO
    {
        public static PedidoDAO instance;

        private PedidoDAO() { }

        public static PedidoDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoDAO();
            }
            return instance;
        }


        
        internal List<PedidoDTO> ConsultarPedidosTodos()
        {
            String connString = ConfigurationManager.ConnectionStrings["pimads4"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String sqlText = "SELECT * FROM Pedidos";
            SqlCommand cmd = new SqlCommand(sqlText, conn);

            List<PedidoDTO> lstPedidos = new List<PedidoDTO>();
            PedidoDTO pedido = null;

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pedido = new PedidoDTO();
                    pedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                    pedido.DtDigitacao = dr["dtDigitacao"].ToString();
                    pedido.ValorTotal = Convert.ToDouble(dr["valorTotal"]);
                    pedido.FormaPagamento = dr["formaPagamento"].ToString();
                    pedido.TpPedido = dr["tpPedido"].ToString();

                    lstPedidos.Add(pedido);
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
            return lstPedidos;
        }
    }
}
