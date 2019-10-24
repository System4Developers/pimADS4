using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class EstadoDAO
    {
        private static EstadoDAO instance;

        private EstadoDAO() { }

        public static EstadoDAO GetInstance()
        {
            if (instance == null)
            {
                return instance = new EstadoDAO();
            }
            return instance;
        }

    }
}
