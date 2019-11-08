using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PedidoVendaProdutoDAO
    {
        private static PedidoVendaProdutoDAO instance;

        private PedidoVendaProdutoDAO() { }

        public static PedidoVendaProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new PedidoVendaProdutoDAO();
            }
            return instance;
        }


    }
}
