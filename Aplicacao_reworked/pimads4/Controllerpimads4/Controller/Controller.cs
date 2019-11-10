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

        public List<PedidoVendaDTO> ConsultarPedidos()
        {
            List<PedidoVendaDTO> lstPedidos = new List<PedidoVendaDTO>();
            lstPedidos = PedidoVendaBL.GetInstance().ConsultarPedidos();
            return lstPedidos;
        }


        #endregion

        #region Metodos Estados

        public List<EstadoDTO> ConsultarEstados()
        {
            List<EstadoDTO> lstEstados = new List<EstadoDTO>();
            lstEstados = EstadoBL.GetInstance().ConsultarEstados();
            return lstEstados;
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

        #region Metodos Bairros
        
        public void CadastrarBairro(BairroDTO bairro)
        {
            BairroBL.GetInstance().CadastrarBairro(bairro);
        }
        public List<BairroDTO> ConsultarBairros()
        {
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = BairroBL.GetInstance().ConsultarBairros();
            return lstBairros;
        }
        public BairroDTO ConsultarBairroById(int idBairro)
        {
            BairroDTO bairro = BairroBL.GetInstance().ConsultarBairroById(idBairro);
            return bairro;
        }
        public void AtualizarBairro(BairroDTO bairro)
        {
            BairroBL.GetInstance().AtualizarBairro(bairro);
        }
        public void ExcluirBairro(int idBairro)
        {
            BairroBL.GetInstance().ExcluirBairro(idBairro);
        }

        #endregion

        #region Metodos Unidade

        public void CadastarUnidade(UnidadeDTO unidade)
        {
            UnidadeBL.GetInstance().CadastrarUnidade(unidade);
        }
        public List<UnidadeDTO> ConsultarUnidades()
        {
            List<UnidadeDTO> lstUnidades = new List<UnidadeDTO>();
            lstUnidades = UnidadeBL.GetInstance().ConsultarUnidades();
            return lstUnidades;
        }
        public UnidadeDTO ConsultarUnidadeById(int idUnidade)
        {
            UnidadeDTO unidade = UnidadeBL.GetInstance().ConsultarUnidadeById(idUnidade);
            return unidade;
        }
        public void AtualizarUnidade(UnidadeDTO unidade)
        {
            UnidadeBL.GetInstance().AtualizarUnidade(unidade);
        }
        public void ExcluirUnidade(int idUnidade)
        {
            UnidadeBL.GetInstance().ExcluirUnidade(idUnidade);
        }

        #endregion

        #region Metodos Produto

        public void CadastrarProduto(ProdutoDTO produto)
        {
            ProdutoBL.GetInstance().CadastrarProduto(produto);
        }
        public List<ProdutoDTO> ConsultarProdutos()
        {
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = ProdutoBL.GetInstance().ConsultarProdutos();
            return lstProdutos;
        }
        public ProdutoDTO ConsultarProdutoById(int idUnidade)
        {
            ProdutoDTO produto = ProdutoBL.GetInstance().ConsultarProdutoById(idUnidade);
            return produto;
        }
        public void AtualizarProduto(ProdutoDTO produto)
        {
            ProdutoBL.GetInstance().AtualizarProduto(produto);
        }
        public void ExcluirProduto(int idProduto)
        {
            ProdutoBL.GetInstance().ExcluirProduto(idProduto);
        }

        #endregion
    }
}
