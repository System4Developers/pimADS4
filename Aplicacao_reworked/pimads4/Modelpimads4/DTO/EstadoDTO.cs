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
        private string dsSigla;
        private string nmEstado;
        private string codIbge;

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string DsSigla { get => dsSigla; set => dsSigla = value; }
        public string NmEstado { get => nmEstado; set => nmEstado = value; }
        public string CodIbge { get => codIbge; set => codIbge = value; }
    }
}
