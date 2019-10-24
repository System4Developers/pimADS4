using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelpimads4.DTO
{
    public class BairroDTO
    {
        private int idBairro;
        private string dsBairro;
        private CidadeDTO cidade;

        public int IdBairro { get => idBairro; set => idBairro = value; }
        public string DsBairro { get => dsBairro; set => dsBairro = value; }
        public CidadeDTO Cidade { get => cidade; set => cidade = value; }

        public BairroDTO()
        {
            Cidade = new CidadeDTO();
        }


    }
}
