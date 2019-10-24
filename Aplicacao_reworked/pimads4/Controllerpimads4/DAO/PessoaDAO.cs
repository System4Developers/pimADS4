using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.DAO
{
    public class PessoaDAO
    {
        private static PessoaDAO instance;

        private PessoaDAO() { }

        public static PessoaDAO GetInstance()
        {
            if(instance == null)
            {
                return instance = new PessoaDAO();
            }

            return instance;
        }


    }
}
