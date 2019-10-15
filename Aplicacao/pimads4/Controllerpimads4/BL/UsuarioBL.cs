using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class UsuarioBL
    {
        private static UsuarioBL instance;

        private UsuarioBL() { }

        public static UsuarioBL GetInstance()
        {
            if (instance == null)
            {
                instance = new UsuarioBL();
            }

            return instance;
        }


    }
}
