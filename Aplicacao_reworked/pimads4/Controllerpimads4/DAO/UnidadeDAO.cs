using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class UnidadeDAO
    {
        private static UnidadeDAO instance;
        
        private UnidadeDAO() { }

        public static UnidadeDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new UnidadeDAO();
            }
                
            return instance;
        }


    }
}
