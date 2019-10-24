using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class ClienteBL
    {
        private static ClienteBL instance;

        private ClienteBL() { }

        public static ClienteBL GetInstance()
        {
            if (instance==null)
            {
                instance = new ClienteBL();
            }

            return instance;
        }


    }
}
