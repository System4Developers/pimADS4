using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class ClienteDAO
    {
        private static ClienteDAO instance;

        private ClienteDAO() { }

        public static ClienteDAO GetInstance()
        {
            if(instance == null)
            {
                return instance = new ClienteDAO();
            }

            return instance;
        }


    }
}
