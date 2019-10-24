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
        private EstadoDTO estado;

        public int IdCidade { get => idCidade; set => idCidade = value; }
        public string Nome { get => nome; set => nome = value; }
        public string CodIbge { get => codIbge; set => codIbge = value; }
        public EstadoDTO Estado { get => estado; set => estado = value; }


        public CidadeDTO()
        {
            Estado = new EstadoDTO();
        }

    }
}
