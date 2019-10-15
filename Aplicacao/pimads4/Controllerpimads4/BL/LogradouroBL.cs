using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class LogradouroBL
    {
        private static LogradouroBL instance;

        private LogradouroBL() { }

        public static LogradouroBL GetInstance()
        {
            if (instance==null)
            {
                instance = new LogradouroBL();
            }

            return instance;
        }


    }
}
