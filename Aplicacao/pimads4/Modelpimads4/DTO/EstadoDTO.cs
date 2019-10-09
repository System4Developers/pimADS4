using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class EstadoDTO
    {
        private int idEstado;
        private string nome;
        private string sigla;
        private string codIbge;

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Sigla { get => sigla; set => sigla = value; }
        public string CodIbge { get => codIbge; set => codIbge = value; }
    }
}
