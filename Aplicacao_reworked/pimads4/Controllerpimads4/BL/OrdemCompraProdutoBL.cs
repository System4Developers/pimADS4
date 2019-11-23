using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class OrdemCompraProdutoBL
    {
        public static OrdemCompraProdutoBL instance;

        private OrdemCompraProdutoBL() { }

        public static OrdemCompraProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraProdutoBL();
            }
            return instance;
        }

    }
}
