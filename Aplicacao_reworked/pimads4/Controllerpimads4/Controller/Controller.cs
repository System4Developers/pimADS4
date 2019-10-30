using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelpimads4.DTO;
using Controllerpimads4.BL;

namespace Controllerpimads4.Controller
{
    public class Controller
    {
        private static Controller instance;

        private Controller() { }

        public static Controller GetInstance()
        {
            if (instance==null)
            {
                instance = new Controller();
            }

            return instance;
        }
        #region Metodos do Usuario
        public void CadastrarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().CadastrarUsuario(usuario);
            
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioBL.GetInstance().ConsultarUsuarios();
            return lstUsuarios;
        }

        public UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            UsuarioDTO usuario = UsuarioBL.GetInstance().ConsultarUsuarioById(idUsuario);
            return usuario;
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().AtualizarUsuario(usuario);
        }

        public void ExcluirUsuario(int idUsuario)
        {
            UsuarioBL.GetInstance().ExcluirUsuario(idUsuario);
        }
        #endregion

        #region Metodos Fabricante
        public void CadastrarFabricante(FabricanteDTO fabricante)
        {
            FabricanteBL.GetInstance().CadastrarFabricante(fabricante);

        }
        
        public List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            lstFabricantes = FabricanteBL.GetInstance().ConsultarFabricanteTodos();
            return lstFabricantes;
        }

        public FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            FabricanteDTO fabricante = FabricanteBL.GetInstance().ConsultarFabricanteById(idFabricante);
            return fabricante;
        }

        public void AtualizarFabricante(FabricanteDTO fabricante)
        {
            FabricanteBL.GetInstance().AtualizarFabricante(fabricante);
        }

        public void ExcluirFabricante(int idFabricante)
        {
            FabricanteBL.GetInstance().ExcluirFabricante(idFabricante);
        }
        #endregion

        #region Metodos Pedido

        public List<PedidoDTO> ConsultarPedidos()
        {
            List<PedidoDTO> lstPedidos = new List<PedidoDTO>();
            lstPedidos = PedidoBL.GetInstance().ConsultarPedidos();
            return lstPedidos;
        }


        #endregion

        #region Metodos Cidades

        public List<CidadeDTO> ConsultarCidades()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeBL.GetInstance().ConsultarCidades();
            return lstCidades;
        }

        #endregion



    }
}
