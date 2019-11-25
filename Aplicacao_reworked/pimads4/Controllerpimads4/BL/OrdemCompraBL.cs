using Controllerpimads4.DAO;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllerpimads4.BL
{
    public class OrdemCompraBL
    {
        public static OrdemCompraBL instance;
        public string mensagem;

        private OrdemCompraBL() { }

        public static OrdemCompraBL GetInstance()
        {
            if (instance== null)
            {
                instance = new OrdemCompraBL();
            }
            return instance;
        }

        internal int CadastrarPedidoCompra(OrdemCompraDTO ordemCompra)
        {
            this.mensagem = "";
            int id_OrdemCompra = 0;

            id_OrdemCompra = OrdemCompraDAO.GetInstance().CadastrarPedidoCompra(ordemCompra);
            if (OrdemCompraDAO.GetInstance().mensagem != "")
            {
                this.mensagem = OrdemCompraDAO.GetInstance().mensagem;
            }
            
            return id_OrdemCompra;
        }
        
        internal List<OrdemCompraDTO> ConsultarOrdemCompraTodos()
        {
            this.mensagem = "";

            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
            listaOrdemCompra = OrdemCompraDAO.GetInstance().ConsultarOrdemCompraTodos();
            if (OrdemCompraDAO.GetInstance().mensagem != "")
            {
                this.mensagem = OrdemCompraDAO.GetInstance().mensagem;
            }
            
            return listaOrdemCompra;
        }


    }
}
