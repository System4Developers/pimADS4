﻿using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedidoVendaBL
    {
        private static PedidoVendaBL instance;

        private PedidoVendaBL() { }

        public static PedidoVendaBL GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoVendaBL();
            }
            return instance;
        }

        internal List<PedidoVendaDTO> ConsultarPedidos()
        {
            List<PedidoVendaDTO> lstPedidos = new List<PedidoVendaDTO>();
            lstPedidos = PedidoVendaDAO.GetInstance().ConsultarPedidosTodos();
            return lstPedidos;
        }



    }
}