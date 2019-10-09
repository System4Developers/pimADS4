using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class LogradouroDTO
    {
        private int idLogradouro;
        private string endereco;
        private string numero;
        private string bairro;
        private string cep;
        private string complemento;
        private int fk_idCidade_cidade;
        private int  fk_idCliente_cliente;

        public int IdLogradouro { get => idLogradouro; set => idLogradouro = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public int Fk_idCidade_cidade { get => fk_idCidade_cidade; set => fk_idCidade_cidade = value; }
        public int Fk_idCliente_cliente { get => fk_idCliente_cliente; set => fk_idCliente_cliente = value; }
    }
}
