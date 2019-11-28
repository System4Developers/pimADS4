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
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PedidoVendaDAO() { }

        public static PedidoVendaDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoVendaDAO();
            }
            return instance;
        }


        internal List<PedidoVendaDTO> ConsultarPedidoVendaTodos()
        {
            this.Mensagem = "";

            String sqlText = "SELECT * FROM PedidoVenda JOIN Pessoas on Pessoas.idPessoa = PedidoVenda.fk_idPessoa_Pessoas";
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
                    pedido.IdPedido = Convert.ToInt32(dr["idPedidoVenda"]);
                    pedido.DtDigitacao = dr["dtDigitacao"].ToString();
                    pedido.ValorTotal = Convert.ToDouble(dr["valorTotal"]);
                    pedido.TpPagamento = dr["tpPagamento"].ToString();
                    pedido.Pessoa.NmPessoa = dr["nmPessoa"].ToString();

                    lstPedidos.Add(pedido);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR PEDIDOS DE VENDA";
            }
            return lstPedidos;
        }

        internal int CadastrarPedidoVenda(PedidoVendaDTO pedidoVenda)
        {
            this.Mensagem = "";
            int id_PedidoVenda = 0;

            string sqlText = string.Format("INSERT INTO PedidoVenda (valorTotal,dtDigitacao,tpPagamento,tpStatus,fk_idPessoa_Pessoas,fk_idUsuario_Usuarios)" +
            " OUTPUT INSERTED.idPedidoVenda VALUES(convert(float,{0}),'{1}','{2}','{3}','{4}','{5}')", pedidoVenda.ValorTotal, pedidoVenda.DtDigitacao, pedidoVenda.TpPagamento, pedidoVenda.TpStatus, pedidoVenda.Pessoa.IdPessoa, pedidoVenda.Usuario.IdUsuario);

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                id_PedidoVenda = (int)cmd.ExecuteScalar();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR PEDIDO DE VENDA";
            }

            return id_PedidoVenda;
        }
    }
}
