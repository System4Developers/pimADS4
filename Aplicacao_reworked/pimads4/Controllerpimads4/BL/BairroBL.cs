using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class BairroBL
    {
        private static BairroBL instance;
           
        private BairroBL() { }

        public static BairroBL GetInstance()
        {
            if (instance==null)
            {
                instance = new BairroBL();
            }

            return instance;
        }

    }
}
