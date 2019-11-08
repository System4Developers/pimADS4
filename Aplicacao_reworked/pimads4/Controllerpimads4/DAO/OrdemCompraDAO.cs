using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class OrdemCompraDAO
    {
        public static OrdemCompraDAO instance;

        private OrdemCompraDAO() { }

        public static OrdemCompraDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new OrdemCompraDAO();
            }
            return instance;
        }


    }
}
