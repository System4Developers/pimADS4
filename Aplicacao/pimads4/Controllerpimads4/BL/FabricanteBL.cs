using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class FabricanteBL
    {
        private static FabricanteBL instance;

        private FabricanteBL() { }

        public static FabricanteBL GetInstace()
        {
            if (instance==null)
            {
                instance = new FabricanteBL();
            }

            return instance;
        }


    }
}
