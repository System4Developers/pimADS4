﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class EstoqueBL
    {
        private static EstoqueBL instance;

        private EstoqueBL() { }

        public static EstoqueBL GetInstance()
        {
            if (instance==null)
            {
                instance = new EstoqueBL();
            }

            return instance;
        }


    }
}