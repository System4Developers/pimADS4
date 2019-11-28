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
        private string mensagem;

        public string Mensagem { get => mensagem; set => mensagem = value; }

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
            this.Mensagem = "";
            UsuarioBL.GetInstance().CadastrarUsuario(usuario);
            if (UsuarioBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }

        public List<UsuarioDTO> ConsultarUsuarios()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = UsuarioBL.GetInstance().ConsultarUsuarios();
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
            return lstUsuarios;
        }

        public UsuarioDTO ConsultarUsuarioById(int idUsuario)
        {
            UsuarioDTO usuario = UsuarioBL.GetInstance().ConsultarUsuarioById(idUsuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
            return usuario;
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            UsuarioBL.GetInstance().AtualizarUsuario(usuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }

        public void ExcluirUsuario(int idUsuario)
        {
            UsuarioBL.GetInstance().ExcluirUsuario(idUsuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }
        public void ValidarLoginUsuario(String Ds_Login, String Ds_Senha)
        {
            UsuarioBL.GetInstance().ValidarLoginUsuario(Ds_Login, Ds_Senha);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }
        #endregion

        #region Metodos Fabricante
        public void CadastrarFabricante(FabricanteDTO fabricante)
        {
            this.Mensagem = "";
            FabricanteBL.GetInstance().CadastrarFabricante(fabricante);
            if (FabricanteBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = FabricanteBL.GetInstance().Mensagem;
            }
        }
        
        public List<FabricanteDTO> ConsultarFabricanteTodos()
        {
            this.Mensagem = "";
            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            lstFabricantes = FabricanteBL.GetInstance().ConsultarFabricanteTodos();
            if (FabricanteBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteBL.GetInstance().Mensagem;
            }
            return lstFabricantes;
        }

        public FabricanteDTO ConsultarFabricanteById(int idFabricante)
        {
            this.Mensagem = "";
            FabricanteDTO fabricante = FabricanteBL.GetInstance().ConsultarFabricanteById(idFabricante);
            if (FabricanteBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteBL.GetInstance().Mensagem;
            }
            return fabricante;
        }

        public void AtualizarFabricante(FabricanteDTO fabricante)
        {
            this.Mensagem = "";
            FabricanteBL.GetInstance().AtualizarFabricante(fabricante);
            if (FabricanteBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteBL.GetInstance().Mensagem;
            }
        }

        public void ExcluirFabricante(int idFabricante)
        {
            this.Mensagem = "";
            FabricanteBL.GetInstance().ExcluirFabricante(idFabricante);
            if (FabricanteBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = FabricanteBL.GetInstance().Mensagem;
            }
        }
        #endregion

        #region Metodos Pedido

        public List<PedidoVendaDTO> ConsultarPedidoVendaTodos()
        {
            this.Mensagem = "";
            List<PedidoVendaDTO> lstPedidos = new List<PedidoVendaDTO>();
            lstPedidos = PedidoVendaBL.GetInstance().ConsultarPedidoVendaTodos();
            if (PedidoVendaBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = PedidoVendaBL.GetInstance().Mensagem;
            }
            return lstPedidos;
        }

        public List<PedidoVendaProdutoDTO> ConsultarProdutosPorIdPedidoVenda(int id_PedidoVenda)
        {
            this.Mensagem = "";
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = PedidoVendaProdutoBL.GetInstance().ConsultarPedidoPorIdPedidoVenda(id_PedidoVenda);
            if (PedidoVendaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaBL.GetInstance().Mensagem;
            }
            return listaPvProduto;
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
        //
        public void CadastrarCidade(CidadeDTO cidade)
        {
            CidadeBL.GetInstance().CadastrarCidade(cidade);
        }

        public List<CidadeDTO> ConsultarCidades()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeBL.GetInstance().ConsultarCidades();
            return lstCidades;
        }

        public List<CidadeDTO> ConsultarCidadesByEstado(int idEstado)
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeBL.GetInstance().ConsultarCidadesByEstado(idEstado);
            return lstCidades;
        }

        public CidadeDTO ConsultarCidadeById(int idCidade)
        {
            CidadeDTO cidade = CidadeBL.GetInstance().ConsultarCidadeById(idCidade);
            return cidade;
        }

        public void AtualizarCidade(CidadeDTO cidade)
        {
            CidadeBL.GetInstance().AtualizarCidade(cidade);
        }

        public void ExcluirCidade(int idCidade)
        {
            CidadeBL.GetInstance().ExcluirCidade(idCidade);
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
        public List<BairroDTO> ConsultarBairrosByCidade(int idCidade)
        {
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = BairroBL.GetInstance().ConsultarBairrosByCidade(idCidade);
            return lstBairros;
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

        #region Metodos Pessoas

        public void CadastrarPessoa(PessoaDTO pessoa)
        {
            PessoaBL.GetInstance().CadastrarPessoa(pessoa);
        }
        public List<PessoaDTO> ConsultarPessoa()
        {
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaBL.GetInstance().ConsultarPessoas();
            return lstPessoas;
        }
        public PessoaDTO ConsultarPessoaById(int idPessoa)
        {
            PessoaDTO pessoa = PessoaBL.GetInstance().ConsultarPessoaById(idPessoa);
            return pessoa;
        }
        public List<PessoaDTO> ConsultarPessoaJuridica()
        {
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            listaPessoaJuridica = PessoaBL.GetInstance().ConsultarPessoaJuridica();
            return listaPessoaJuridica;
        }
        public void AtualizarPessoa(PessoaDTO pessoa)
        {
            PessoaBL.GetInstance().AtualizarPessoa(pessoa);
        }
        public void ExcluirPessoa(int idPessoa)
        {
            PessoaBL.GetInstance().ExcluirPessoa(idPessoa);
        }

        #endregion

        #region Metodos Ordem de Compra
        public void VerificarProdutoOc(OrdemCompraProdutoDTO produtoOc)
        {
            this.Mensagem = "";
            OrdemCompraProdutoBL.GetInstance().VerificarProdutoOc(produtoOc);
            if (OrdemCompraProdutoBL.GetInstance().mensagem !="")
            {
                this.Mensagem = OrdemCompraProdutoBL.GetInstance().mensagem;
            }
        }

        public void AdicionarQuantidadeProdutoOc(List<OrdemCompraProdutoDTO> listaProdutosOc,int index)
        {
            this.Mensagem = "";
            OrdemCompraProdutoBL.GetInstance().AdicionarQuantidadeProdutoOc(listaProdutosOc, index);

            if (OrdemCompraProdutoBL.GetInstance().mensagem!="")
            {
                this.Mensagem = OrdemCompraProdutoBL.GetInstance().mensagem;
            }
        }

        public void RemoverQuantidadeProdutoOc(List<OrdemCompraProdutoDTO> listaProdutosOc, int index)
        {
            this.Mensagem = "";
            OrdemCompraProdutoBL.GetInstance().RemoverQuantidadeProdutoOc(listaProdutosOc, index);

            if (OrdemCompraProdutoBL.GetInstance().mensagem!="")
            {
                this.Mensagem = OrdemCompraProdutoBL.GetInstance().mensagem;
            }
        }

        public double OcProdCalcularValorTotal(List<OrdemCompraProdutoDTO> listaProdutosOc)
        {
            this.Mensagem = "";
            double vlTotal=0;

            try
            {
                vlTotal = OrdemCompraProdutoBL.GetInstance().OcProdCalcularValorTotal(listaProdutosOc);
                if (OrdemCompraProdutoBL.GetInstance().mensagem != "")
                {
                    this.Mensagem = OrdemCompraProdutoBL.GetInstance().mensagem;
                }
            }
            catch (Exception ex)
            {
                this.Mensagem = "NAO FOI POSSIVEL CALCULAR O VALOR TOTAL";
            }

            return vlTotal;
        }

        public void CadastrarOrdemCompra(OrdemCompraDTO ordemCompra,List<OrdemCompraProdutoDTO> listaOcProduto)
        {
            this.Mensagem = "";

            OrdemCompraBL.GetInstance().CadastrarOrdemCompra(ordemCompra, listaOcProduto);
            if (OrdemCompraBL.GetInstance().mensagem != "")
            {
                this.Mensagem = OrdemCompraBL.GetInstance().mensagem;
            }
            
        }

        public List<OrdemCompraDTO> ConsultarOrdemCompraTodos()
        {
            this.Mensagem = "";
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();

            listaOrdemCompra = OrdemCompraBL.GetInstance().ConsultarOrdemCompraTodos();
            if (OrdemCompraBL.GetInstance().mensagem!="")
            {
                this.Mensagem = OrdemCompraBL.GetInstance().mensagem;
            }

            return listaOrdemCompra;
        }

        public List<OrdemCompraProdutoDTO> ConsultarProdutosPorIdOrdemCompra(int id_OrdemCompra)
        {
            this.Mensagem = "";
            List<OrdemCompraProdutoDTO> listaProdutoOc = new List<OrdemCompraProdutoDTO>();
            listaProdutoOc = OrdemCompraProdutoBL.GetInstance().ConsultarProdutosPorIdOrdemCompra(id_OrdemCompra);
            return listaProdutoOc;
        }

        #endregion

        #region Metodos Pedido de Venda

        public void VerificarProdutoPv(PedidoVendaProdutoDTO pvProduto)
        {
            this.Mensagem = "";
            PedidoVendaProdutoBL.GetInstance().VerificarProdutoPv(pvProduto);
            if (PedidoVendaProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoBL.GetInstance().Mensagem;
            }
        }

        public void PvProdCalcularValorTotal(List<PedidoVendaProdutoDTO> listaPvProduto,PedidoVendaDTO pedidoVenda)
        {
            this.Mensagem = "";
           
            PedidoVendaProdutoBL.GetInstance().PvProdCalcularValorTotal(listaPvProduto, pedidoVenda);
            if (PedidoVendaProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoBL.GetInstance().Mensagem;
            }
        }

        public void AdicionarQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.Mensagem = "";
            PedidoVendaProdutoBL.GetInstance().AdicionarQuantidadeProdutoPv(listaPvProduto, index);

            if (PedidoVendaProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoBL.GetInstance().Mensagem;
            }
        }

        public void RemoverQuantidadeProdutoPv(List<PedidoVendaProdutoDTO> listaPvProduto, int index)
        {
            this.Mensagem = "";
            PedidoVendaProdutoBL.GetInstance().RemoverQuantidadeProdutoPv(listaPvProduto, index);

            if (PedidoVendaProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaProdutoBL.GetInstance().Mensagem;
            }
        }

        public void CadastrarPedidoVenda(PedidoVendaDTO pedidoVenda, List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";

            PedidoVendaBL.GetInstance().CadastrarPedidoVenda(pedidoVenda, listaPvProduto);
            if (PedidoVendaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PedidoVendaBL.GetInstance().Mensagem;
            }
            else
            {
                ProdutoBL.GetInstance().AtualizarProdutoQuantidadePv(listaPvProduto);
                if (ProdutoBL.GetInstance().Mensagem != "")
                {
                    this.Mensagem = ProdutoBL.GetInstance().Mensagem;
                }
            }
        }
        #endregion

    }
}
