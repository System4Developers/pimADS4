using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class ProdutoBL
    {
        private static ProdutoBL instance;
        
        private ProdutoBL() { }

        public static ProdutoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new ProdutoBL();
            }

            return instance;
        }
        
        

    }
}
