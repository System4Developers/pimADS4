using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class ProdutoDAO
    {
        private static ProdutoDAO instance;

        private ProdutoDAO() { }

        public static ProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new ProdutoDAO();
            }
            return instance;
        }

    }
}
