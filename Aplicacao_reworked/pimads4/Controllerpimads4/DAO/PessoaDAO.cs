using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PessoaDAO
    {
        private static PessoaDAO instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PessoaDAO() { }

        public static PessoaDAO GetInstance()
        {
            if(instance == null)
            {
                return instance = new PessoaDAO();
            }

            return instance;
        }

        internal void CadastrarPessoa(PessoaDTO mObj)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_CadastrarPessoa", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tpPessoa", mObj.TpPessoa);
            cmd.Parameters.AddWithValue("@nmPessoa", mObj.NmPessoa);
            cmd.Parameters.AddWithValue("@numDocumento", mObj.NumDocumento);
            cmd.Parameters.AddWithValue("@numRG",mObj.NumRG);
            cmd.Parameters.AddWithValue("@dtNascimento", mObj.DtNascimento);
            cmd.Parameters.AddWithValue("@dsEmail", mObj.DsEmail);
            cmd.Parameters.AddWithValue("@dsEndereco", mObj.DsEndereco);
            cmd.Parameters.AddWithValue("@complemento", mObj.Complemento);
            cmd.Parameters.AddWithValue("@numEnd", mObj.NumEnd);
            cmd.Parameters.AddWithValue("@observacao", mObj.Observacao);
            cmd.Parameters.AddWithValue("@fk_idBairro_Bairros", mObj.Bairro.IdBairro);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();

            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CADASTRAR PESSOA";
            }

        }

        internal List<PessoaDTO> ConsultarPessoaTodos()
        {
            this.Mensagem = "";

            String sqlText = "SELECT * FROM Pessoas";
            SqlCommand cmd = new SqlCommand(sqlText, ConexaoDAO.GetInstance().Conexao());

            List<PessoaDTO> lstObj = new List<PessoaDTO>();
            PessoaDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mObj = new PessoaDTO();
                    mObj.IdPessoa = Convert.ToInt32(dr["idPessoa"]);
                    mObj.TpPessoa = dr["tpPessoa"].ToString();
                    mObj.NmPessoa = dr["nmPessoa"].ToString();
                    mObj.NumDocumento = dr["numDocumento"].ToString();
                    mObj.NumRG = dr["numRG"].ToString();
                    mObj.DtNascimento = dr["dtNascimento"].ToString();
                    mObj.DsEmail = dr["dsEmail"].ToString();
                    mObj.DsEndereco = dr["dsEndereco"].ToString();
                    mObj.Complemento = dr["complemento"].ToString();
                    mObj.NumEnd = dr["numEnd"].ToString();
                    mObj.Observacao = dr["observacao"].ToString();
                    mObj.Bairro.IdBairro = Convert.ToInt32(dr["fk_idBairro_Bairros"]);

                    lstObj.Add(mObj);
                }

                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR DADOS PESSOA";
            }
            return lstObj;
        }

        internal PessoaDTO ConsultarPessoaById(int idAtributo)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_ConsultarPessoaById", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPessoa", idAtributo);

            PessoaDTO mObj = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                          
                while (dr.Read())
                {
                    mObj = new PessoaDTO();
                    mObj.IdPessoa = Convert.ToInt32(dr["idPessoa"]);
                    mObj.TpPessoa = dr["tpPessoa"].ToString();
                    mObj.NmPessoa = dr["nmPessoa"].ToString();
                    mObj.NumDocumento = dr["numDocumento"].ToString();
                    mObj.NumRG = dr["numRG"].ToString();
                    mObj.DtNascimento = dr["dtNascimento"].ToString();
                    mObj.DsEmail = dr["dsEmail"].ToString();
                    mObj.DsEndereco = dr["dsEndereco"].ToString();
                    mObj.Complemento = dr["complemento"].ToString();
                    mObj.NumEnd = dr["numEnd"].ToString();
                    mObj.Observacao = dr["observacao"].ToString();
                    mObj.Bairro.IdBairro = Convert.ToInt32(dr["fk_idBairro_Bairros"]);
                    mObj.Bairro.Cidade.IdCidade = Convert.ToInt32(dr["fk_idCidade_Cidades"]);
                    mObj.Bairro.Cidade.Estado.IdEstado = Convert.ToInt32(dr["fk_idEstado_Estados"]);
                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO CONSULTAR PESSOA ID: " + idAtributo;
            }
            return mObj;
        }

        internal List<PessoaDTO> ConsultarPessoaJuridica()
        {
            this.Mensagem = "";

            SqlCommand cmd = new SqlCommand("Select * from Pessoas where tpPessoa='J'", ConexaoDAO.GetInstance().Conexao());
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            PessoaDTO pessoa = null;

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pessoa = new PessoaDTO();
                    pessoa.IdPessoa = Convert.ToInt32(dr["idPessoa"]);
                    pessoa.NmPessoa = dr["nmPessoa"].ToString();
                    listaPessoaJuridica.Add(pessoa);

                }
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {

                this.Mensagem = "FALHA AO CONSULTAR PESSOAS POR TIPO";
            }

            return listaPessoaJuridica;
        }

        internal void AtualizarPessoa(PessoaDTO mObj)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_AtualizarPessoa", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPessoa", mObj.IdPessoa);
            cmd.Parameters.AddWithValue("@tpPessoa", mObj.TpPessoa);
            cmd.Parameters.AddWithValue("@nmPessoa", mObj.NmPessoa);
            cmd.Parameters.AddWithValue("@numDocumento", mObj.NumDocumento);
            cmd.Parameters.AddWithValue("@numRG", mObj.NumRG);
            cmd.Parameters.AddWithValue("@dtNascimento", mObj.DtNascimento);
            cmd.Parameters.AddWithValue("@dsEmail", mObj.DsEmail);
            cmd.Parameters.AddWithValue("@dsEndereco", mObj.DsEndereco);
            cmd.Parameters.AddWithValue("@complemento", mObj.Complemento);
            cmd.Parameters.AddWithValue("@numEnd", mObj.NumEnd);
            cmd.Parameters.AddWithValue("@observacao", mObj.Observacao);
            cmd.Parameters.AddWithValue("@fk_idBairro_Bairros", mObj.Bairro.IdBairro);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO ATUALIZAR DADOS DE PESSOA";
            }

        }

        internal void ExlcuirPessoa(int idAtributo)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand("sp_ExcluirPessoa", ConexaoDAO.GetInstance().Conexao());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPessoa", idAtributo);

            try
            {
                ConexaoDAO.GetInstance().Conectar();
                cmd.ExecuteNonQuery();
                ConexaoDAO.GetInstance().Desconectar();
            }
            catch (Exception ex)
            {
                ConexaoDAO.GetInstance().Desconectar();
                this.Mensagem = "FALHA AO EXLCUIR PESSOA";
            }

        }

    }
}
