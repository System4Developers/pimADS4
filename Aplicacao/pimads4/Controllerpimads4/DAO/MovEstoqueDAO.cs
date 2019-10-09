using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class MovEstoqueDAO
    {
        private static string instance;

        private MovEstoqueDAO()
        {

        }

        public static MovEstoqueDAO GetInstance(MovEstoqueDAO instance)
        {
            if (instance==null)
            {
                instance = new MovEstoqueDAO();
            }

            return instance;
        }
    }
}
