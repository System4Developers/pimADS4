using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class PedidoBL
    {
        private static PedidoBL instance;

        private PedidoBL() { }

        public static PedidoBL GetInstance()
        {
            if (instance == null)
            {
                instance = new PedidoBL();
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
