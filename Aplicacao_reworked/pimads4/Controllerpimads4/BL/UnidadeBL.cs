using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class UnidadeBL
    {
        private static UnidadeBL instance;

        private UnidadeBL() { }

        public static UnidadeBL GetInstance()
        {

            if (instance==null)
            {
                instance = new UnidadeBL();
            }

            return instance;
        }


    }
}
