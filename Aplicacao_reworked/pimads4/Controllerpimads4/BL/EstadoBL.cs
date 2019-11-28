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
        private string mensagem;

        private EstadoBL() { }

        public string Mensagem { get => mensagem; set => mensagem = value; }

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
            this.Mensagem = "";
            List<EstadoDTO> lstEstados = new List<EstadoDTO>();
            lstEstados = EstadoDAO.GetInstance().ConsultarEstadosTodos();
            if (EstadoDAO.GetInstance().Mensagem!="")
            {
                this.Mensagem = EstadoDAO.GetInstance().Mensagem;
            }
            return lstEstados;

        }
    }
}
