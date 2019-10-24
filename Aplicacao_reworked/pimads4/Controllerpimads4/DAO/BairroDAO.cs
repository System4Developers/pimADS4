using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class BairroDAO
    {
        private static BairroDAO instance;

        private BairroDAO() { }

        public static BairroDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new BairroDAO();
            }

            return instance;
        }

    }
}
