using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PessoaBL
    {
        private static PessoaBL instance;
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

        private PessoaBL() { }

        public static PessoaBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PessoaBL();
            }

            return instance;
        }

        internal void CadastrarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";

            if (pessoa.TpPessoa =="F")
            {
                if (!IsCpf(pessoa.NumDocumento))
                {
                    this.mensagem = "CPF INFORMADO INVÁLIDO";
                    return;
                }
            }
            if (pessoa.TpPessoa == "J")
            {
                if (!IsCnpj(pessoa.NumDocumento))
                {
                    this.Mensagem = "CNPJ INFORMADO INVÁLIDO";
                    return;
                }
            }
            if (pessoa.NmPessoa == "")
            {
                this.Mensagem = "CAMPO NOME NAO PREENCHIDO";
                return;
            }
            if (pessoa.Bairro.IdBairro <=0)
            {
                this.Mensagem = "BAIRRO NAO INFORMADO";
                return;
            }

            if (PessoaDAO.GetInstance().ConsultarPessoaByDoc(pessoa.NumDocumento))
            {
                this.Mensagem = "CLIENTE/FORNECEDOR JA CADASTRADO COM ESSE NUMERO DE DOCUMENTO: "+ pessoa.NumDocumento + "";
                return;
            }
            PessoaDAO.GetInstance().CadastrarPessoa(pessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
                return;
            }
        }
        internal void AtualizarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";

            if (pessoa.TpPessoa == "F")
            {
                if (!IsCpf(pessoa.NumDocumento))
                {
                    this.mensagem = "CPF INFORMADO INVÁLIDO";
                    return;
                }
            }
            if (pessoa.TpPessoa == "J")
            {
                if (!IsCnpj(pessoa.NumDocumento))
                {
                    this.Mensagem = "CNPJ INFORMADO INVÁLIDO";
                    return;
                }
            }
            if (pessoa.NmPessoa == "")
            {
                this.Mensagem = "CAMPO NOME NÃO PREENCHIDO";
                return;
            }
            if (pessoa.Bairro.IdBairro <= 0)
            {
                this.Mensagem = "BAIRRO NÃO INFORMADO";
                return;
            }
            PessoaDAO.GetInstance().AtualizarPessoa(pessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
        }


        internal List<PessoaDTO> ConsultarPessoas()
        {
            this.Mensagem = "";
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaDAO.GetInstance().ConsultarPessoaTodos();
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return lstPessoas;
        }

        internal List<PessoaDTO> ConsultarPessoaByNmDoc(string NmPessoa, string NumDoc)
        {
            this.Mensagem = "";
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaDAO.GetInstance().ConsultarPessoaByNmDoc( NmPessoa,NumDoc);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return lstPessoas;
        }

        internal PessoaDTO ConsultarPessoaById(int idPessoa)
        {
            this.Mensagem = "";
            PessoaDTO pessoa = PessoaDAO.GetInstance().ConsultarPessoaById(idPessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return pessoa;
        }

       
        internal void ExcluirPessoa(int idPessoa)
        {
            this.Mensagem = "";
            PessoaDAO.GetInstance().ExlcuirPessoa(idPessoa);
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
        }

        internal List<PessoaDTO> ConsultarPessoaJuridica()
        {
            this.Mensagem = "";
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            listaPessoaJuridica = PessoaDAO.GetInstance().ConsultarPessoaJuridica();
            if (PessoaDAO.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaDAO.GetInstance().Mensagem;
            }
            return listaPessoaJuridica;
        }

        // metodo retirado de macoratti.net/11/09/c_val1.htm
        private bool IsCnpj(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        // metodo retirado de macoratti.net/11/09/c_val1.htm
        private bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
