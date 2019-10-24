using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class CidadeDAO
    {
        private static CidadeDAO instance;

        private CidadeDAO() { }

        public static CidadeDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new CidadeDAO();
            }
            return instance;
        }

    }
}
