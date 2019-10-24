using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PedProdutoDAO
    {
        private static PedProdutoDAO instance;

        private PedProdutoDAO() { }

        public static PedProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new PedProdutoDAO();
            }
            return instance;
        }


    }
}
