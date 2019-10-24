using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class EstoqueDAO
    {
        private static EstoqueDAO instance;

        private EstoqueDAO() { }

        public static EstoqueDAO GetInstance()
        {
            if (instance==null)
            {
                instance = new EstoqueDAO();
            }
                
            return instance;
        } 
    }

}
