using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class LogradouroDAO
    {
        private static LogradouroDAO instance;

        private LogradouroDAO()
        { }

        public static LogradouroDAO GetInstance(LogradouroDAO instance)
        {
            if (instance==null)
            {
                instance = new LogradouroDAO();
            }

            return instance;
        }

    }
}
