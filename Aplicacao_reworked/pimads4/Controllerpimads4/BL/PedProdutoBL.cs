using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedProdutoBL
    {
        private static PedProdutoBL instance;

        private PedProdutoBL() { }

        public static PedProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PedProdutoBL();
            }

            return instance;
        }

    }
}
