using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PessoaBL
    {
        private static PessoaBL instance;

        private PessoaBL() { }

        public static PessoaBL GetInstance()
        {
            if (instance==null)
            {
                instance = new PessoaBL();
            }

            return instance;
        }


    }
}
