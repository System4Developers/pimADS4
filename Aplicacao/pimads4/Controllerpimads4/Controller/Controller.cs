using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.Controller
{
    public class Controller
    {
        private static Controller instance;

        private Controller() { }

        public static Controller GetInstance()
        {
            if (instance==null)
            {
                instance = new Controller();
            }

            return instance;
        }
       


        
    }
}
