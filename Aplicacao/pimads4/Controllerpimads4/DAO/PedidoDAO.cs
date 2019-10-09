using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PedidoDAO
    {
        public static PedidoDAO instance;

        private PedidoDAO()
        { }

        public static PedidoDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoDAO();
            }
            return instance;
        }

    }
}
