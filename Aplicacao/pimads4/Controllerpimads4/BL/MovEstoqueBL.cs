using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class MovEstoqueBL
    {
        private static MovEstoqueBL instance;

        private MovEstoqueBL() { }

        public static MovEstoqueBL GetInstance()
        {
            if (instance==null)
            {
                instance = new MovEstoqueBL();
            }

            return instance;
        }

    }
}
