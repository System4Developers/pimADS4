using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class FabricanteDTO
    {
        private int idFabricante;
        private string nome;

        public int IdFabricante { get => idFabricante; set => idFabricante = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
