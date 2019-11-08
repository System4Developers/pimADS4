using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class OrdemCompraBL
    {
        public static OrdemCompraBL instance;

        private OrdemCompraBL() { }

        public static OrdemCompraBL GetInstance()
        {
            if (instance== null)
            {
                instance = new OrdemCompraBL();
            }
            return instance;
        }



    }
}
