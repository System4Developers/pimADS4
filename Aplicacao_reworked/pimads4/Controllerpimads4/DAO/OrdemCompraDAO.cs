using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraDAO
    {
        public static OrdemCompraDAO instance;
        public String mensagem;

        private OrdemCompraDAO() { }

        public static OrdemCompraDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraDAO();
            }
            return instance;
        }


        internal int CadastrarPedidoCompra(OrdemCompraDTO ordemCompra)
        {
            this.mensagem = "";
            int id_OrdemCompra=0;
            
            string sqlText = string.Format("insert into OrdemCompra (valorTotal,dtDigitacao,tpStatus,fk_idUsuario_Usuarios,fk_idPessoa_Pessoas)" +
            " OUTPUT INSERTED.idOrdemCompra VALUES({0},'{1}','{2}',{3},{4})",ordemCompra.ValorTotal, ordemCompra.DtDigitacao, ordemCompra.TpStatus, ordemCompra.Pessoa.IdPessoa,ordemCompra.Usuario.IdUsuario);
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                id_OrdemCompra = (int)cmd.ExecuteScalar();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
               ConexaoDAO.GetInstance().Desconectar();
               this.mensagem = ex.Message + " - " + "\n" + cmd.CommandText + "\n" + ex;
            }

            return id_OrdemCompra;
        }

    }
}
