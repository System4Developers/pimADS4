using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedidoVendaProdutoBL
    {
        private static PedidoVendaProdutoBL instance;

        private PedidoVendaProdutoBL() { }

        public static PedidoVendaProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PedidoVendaProdutoBL();
            }

            return instance;
        }

    }
}
