using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class EstadoBL
    {
        private static EstadoBL instance;

        private EstadoBL() { }

        public static EstadoBL GetInstance()
        {
            if (instance==null)
            {
                instance = new EstadoBL();
            }

            return instance;
        }

        internal List<EstadoDTO> ConsultarEstados()
        {
            List<EstadoDTO> lstEstados = new List<EstadoDTO>();
            lstEstados = EstadoDAO.GetInstance().ConsultarEstadosTodos();
            return lstEstados;

        }
    }
}
