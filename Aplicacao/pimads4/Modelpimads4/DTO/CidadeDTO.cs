using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class CidadeDTO
    {
        private int idCidade;
        private string nome;
        private string codIbge;
        private int fk_idEstado_estado;

        public int IdCidade { get => idCidade; set => idCidade = value; }
        public string Nome { get => nome; set => nome = value; }
        public string CodIbge { get => codIbge; set => codIbge = value; }
        public int Fk_idEstado_estado { get => fk_idEstado_estado; set => fk_idEstado_estado = value; }


    }
}
