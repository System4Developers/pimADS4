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
            int id_Usuario = estPropriedades.Id_Usuario;
            
            string sqlText = string.Format("insert into OrdemCompra (valorTotal,dtDigitacao,tpStatus,fk_idUsuario_Usuarios,fk_idPessoa_Pessoas)" +
            " OUTPUT INSERTED.idOrdemCompra VALUES({0},'{1}','{2}',{3},{4})",ordemCompra.ValorTotal, ordemCompra.DtDigitacao, ordemCompra.TpStatus, ordemCompra.Pessoa.IdPessoa,id_Usuario);

            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

           /* SqlCommand cmd = new SqlCommand("insert into OrdemCompra(valorTotal, dtDigitacao, tpStatus, fk_idUsuario_Usuarios, fk_idPessoa_Pessoas)" +
            " OUTPUT INSERTED.idOrdemCompra VALUES(@valorTotal,'@dtDigitacao','@Status',1,@idPessoa)", ConexaoDAO.GetInstance().Conexao());

            /* "insert into OrdemCompra (valorTotal,dtDigitacao,tpStatus,fk_idUsuario_Usuarios,fk_idPessoa_Pessoas)" +
             " OUTPUT INSERTED.idOrdemCompra VALUES(@valorTotal,'@dtDigitacao','@Status', @idUsuario, @idPessoa)"
             
             cmd.Parameters.AddWithValue("@valorTotal", ordemCompra.ValorTotal);
             cmd.Parameters.AddWithValue("@dtDigitacao", ordemCompra.DtDigitacao);
             cmd.Parameters.AddWithValue("@Status", ordemCompra.TpStatus);
             cmd.Parameters.AddWithValue("@idUsuario", ordemCompra.Usuario.IdUsuario);
             cmd.Parameters.AddWithValue("@idPessoa", ordemCompra.Pessoa.IdPessoa);*/

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
