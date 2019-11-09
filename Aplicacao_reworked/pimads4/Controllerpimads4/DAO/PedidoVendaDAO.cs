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
    public class PedidoVendaDAO
    {
        public static PedidoVendaDAO instance;

        private PedidoVendaDAO() { }

        public static PedidoVendaDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoVendaDAO();
            }
            return instance;
        }


        internal List<PedidoVendaDTO> ConsultarPedidosTodos()
        {
            String sqlText = "SELECT * FROM PedidoVenda";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<PedidoVendaDTO> lstPedidos = new List<PedidoVendaDTO>();
            PedidoVendaDTO pedido = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pedido = new PedidoVendaDTO();
                    pedido.IdPedido = Convert.ToInt32(dr["idPedido"]);
                    pedido.DtDigitacao = dr["dtDigitacao"].ToString();
                    pedido.ValorTotal = Convert.ToDouble(dr["valorTotal"]);
                    pedido.TpPagamento = dr["formaPagamento"].ToString();

                    lstPedidos.Add(pedido);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                throw new InvalidOperationException(ex.Message + " - " + cmd.CommandText, ex);
            }
            return lstPedidos;
        }
    }
}
