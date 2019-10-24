using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class CidadeBL
    {
        private static CidadeBL instance;

        private CidadeBL() { }

        public static CidadeBL GetInstance()
        {
            if (instance==null)
            {
                instance = new CidadeBL();
            }

            return instance;
        }

    }
}
