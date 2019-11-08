using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraProdutoDAO
    {
        public static OrdemCompraProdutoDAO instance;

        private OrdemCompraProdutoDAO() { }

        public static OrdemCompraProdutoDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraProdutoDAO();
            }
            return instance;
        }


    }
}
