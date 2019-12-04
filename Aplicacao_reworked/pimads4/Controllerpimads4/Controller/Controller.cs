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
            this.Mensagem = "";
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
            this.Mensagem = "";
            UsuarioDTO usuario = UsuarioBL.GetInstance().ConsultarUsuarioById(idUsuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
            return usuario;
        }

        public void AtualizarUsuario(UsuarioDTO usuario)
        {
            this.Mensagem = "";
            UsuarioBL.GetInstance().AtualizarUsuario(usuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }

        public void ExcluirUsuario(int idUsuario)
        {
            this.Mensagem = "";
            UsuarioBL.GetInstance().ExcluirUsuario(idUsuario);
            if (UsuarioBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UsuarioBL.GetInstance().Mensagem;
            }
        }
        public void ValidarLoginUsuario(String Ds_Login, String Ds_Senha)
        {
            this.Mensagem = "";
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
            this.Mensagem = "";
            List<EstadoDTO> lstEstados = new List<EstadoDTO>();
            lstEstados = EstadoBL.GetInstance().ConsultarEstados();
            if (EstadoBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = EstadoBL.GetInstance().Mensagem;
            }
            return lstEstados;
        }

        #endregion

        #region Metodos Cidades
        //
        public void CadastrarCidade(CidadeDTO cidade)
        {
            this.Mensagem = "";
            CidadeBL.GetInstance().CadastrarCidade(cidade);
            if (CidadeBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
        }

        public List<CidadeDTO> ConsultarCidades()
        {
            this.Mensagem = "";
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeBL.GetInstance().ConsultarCidades();
            if (CidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
            return lstCidades;
        }

        public List<CidadeDTO> ConsultarCidadesByEstado(int idEstado)
        {
            this.Mensagem = "";
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = CidadeBL.GetInstance().ConsultarCidadesByEstado(idEstado);
            if (CidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
            return lstCidades;
        }

        public CidadeDTO ConsultarCidadeById(int idCidade)
        {
            this.Mensagem = "";
            CidadeDTO cidade = CidadeBL.GetInstance().ConsultarCidadeById(idCidade);
            if (CidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
            return cidade;
        }

        public void AtualizarCidade(CidadeDTO cidade)
        {
            this.Mensagem = "";
            CidadeBL.GetInstance().AtualizarCidade(cidade);
            if (CidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
        }

        public void ExcluirCidade(int idCidade)
        {
            this.Mensagem = "";
            CidadeBL.GetInstance().ExcluirCidade(idCidade);
            if (CidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = CidadeBL.GetInstance().Mensagem;
            }
        }

        #endregion

        #region Metodos Bairros

        public void CadastrarBairro(BairroDTO bairro)
        {
            this.Mensagem = "";
            BairroBL.GetInstance().CadastrarBairro(bairro);
            if (BairroBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
        }
        public List<BairroDTO> ConsultarBairros()
        {
            this.Mensagem = "";
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = BairroBL.GetInstance().ConsultarBairros();
            if (BairroBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
            return lstBairros;
        }
        public BairroDTO ConsultarBairroById(int idBairro)
        {
            this.Mensagem = "";
            BairroDTO bairro = BairroBL.GetInstance().ConsultarBairroById(idBairro);
            if (BairroBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
            return bairro;
        }
        public void AtualizarBairro(BairroDTO bairro)
        {
            this.Mensagem = "";
            BairroBL.GetInstance().AtualizarBairro(bairro);
            if (BairroBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
        }
        public void ExcluirBairro(int idBairro)
        {
            this.Mensagem = "";
            BairroBL.GetInstance().ExcluirBairro(idBairro);
            if (BairroBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
        }
        public List<BairroDTO> ConsultarBairrosByCidade(int idCidade)
        {
            this.Mensagem = "";
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = BairroBL.GetInstance().ConsultarBairrosByCidade(idCidade);
            if (BairroBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = BairroBL.GetInstance().Mensagem;
            }
            return lstBairros;
        }
        #endregion

        #region Metodos Unidade

        public void CadastarUnidade(UnidadeDTO unidade)
        {
            this.Mensagem = "";
            UnidadeBL.GetInstance().CadastrarUnidade(unidade);
            if (UnidadeBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = UnidadeBL.GetInstance().Mensagem;
            }
        }
        public List<UnidadeDTO> ConsultarUnidades()
        {
            this.Mensagem = "";
            List<UnidadeDTO> lstUnidades = new List<UnidadeDTO>();
            lstUnidades = UnidadeBL.GetInstance().ConsultarUnidades();
            if (UnidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeBL.GetInstance().Mensagem;
            }
            return lstUnidades;
        }
        public UnidadeDTO ConsultarUnidadeById(int idUnidade)
        {
            this.Mensagem = "";
            UnidadeDTO unidade = UnidadeBL.GetInstance().ConsultarUnidadeById(idUnidade);
            if (UnidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeBL.GetInstance().Mensagem;
            }
            return unidade;
        }
        public void AtualizarUnidade(UnidadeDTO unidade)
        {
            this.Mensagem = "";
            UnidadeBL.GetInstance().AtualizarUnidade(unidade);
            if (UnidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeBL.GetInstance().Mensagem;
            }
        }
        public void ExcluirUnidade(int idUnidade)
        {
            this.Mensagem = "";
            UnidadeBL.GetInstance().ExcluirUnidade(idUnidade);
            if (UnidadeBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = UnidadeBL.GetInstance().Mensagem;
            }
        }

        #endregion

        #region Metodos Produto

        public void CadastrarProduto(ProdutoDTO produto)
        {
            this.Mensagem = "";
            ProdutoBL.GetInstance().CadastrarProduto(produto);
            if (ProdutoBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = ProdutoBL.GetInstance().Mensagem;
            }
        }
        public List<ProdutoDTO> ConsultarProdutos()
        {
            this.Mensagem = "";
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = ProdutoBL.GetInstance().ConsultarProdutos();
            if (ProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoBL.GetInstance().Mensagem;
            }
            return lstProdutos;
        }
        public ProdutoDTO ConsultarProdutoById(int idUnidade)
        {
            this.Mensagem = "";
            ProdutoDTO produto = ProdutoBL.GetInstance().ConsultarProdutoById(idUnidade);
            if (ProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoBL.GetInstance().Mensagem;
            }
            return produto;
        }
        public void AtualizarProduto(ProdutoDTO produto)
        {
            this.Mensagem = "";
            ProdutoBL.GetInstance().AtualizarProduto(produto);
            if (ProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoBL.GetInstance().Mensagem;
            }
        }
        public void ExcluirProduto(int idProduto)
        {
            this.Mensagem = "";
            ProdutoBL.GetInstance().ExcluirProduto(idProduto);
            if (ProdutoBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = ProdutoBL.GetInstance().Mensagem;
            }
        }

        #endregion

        #region Metodos Pessoas

        public void CadastrarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";
            PessoaBL.GetInstance().CadastrarPessoa(pessoa);
            if (PessoaBL.GetInstance().Mensagem!="")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
        }
        public List<PessoaDTO> ConsultarPessoa()
        {
            this.Mensagem = "";
            List<PessoaDTO> lstPessoas = new List<PessoaDTO>();
            lstPessoas = PessoaBL.GetInstance().ConsultarPessoas();
            if (PessoaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
            return lstPessoas;
        }
        public PessoaDTO ConsultarPessoaById(int idPessoa)
        {
            this.Mensagem = "";
            PessoaDTO pessoa = PessoaBL.GetInstance().ConsultarPessoaById(idPessoa);
            if (PessoaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
            return pessoa;
        }
        public List<PessoaDTO> ConsultarPessoaJuridica()
        {
            this.Mensagem = "";
            List<PessoaDTO> listaPessoaJuridica = new List<PessoaDTO>();
            listaPessoaJuridica = PessoaBL.GetInstance().ConsultarPessoaJuridica();
            if (PessoaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
            return listaPessoaJuridica;
        }
        public void AtualizarPessoa(PessoaDTO pessoa)
        {
            this.Mensagem = "";
            PessoaBL.GetInstance().AtualizarPessoa(pessoa);
            if (PessoaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
        }
        public void ExcluirPessoa(int idPessoa)
        {
            this.Mensagem = "";
            PessoaBL.GetInstance().ExcluirPessoa(idPessoa);
            if (PessoaBL.GetInstance().Mensagem != "")
            {
                this.Mensagem = PessoaBL.GetInstance().Mensagem;
            }
        }

        #endregion

        #region Metodos Ordem de Compra
        public void VerificarProdutoOc(OrdemCompraProdutoDTO produtoOc,List<OrdemCompraProdutoDTO> listaOcProduto)
        {
            this.Mensagem = "";
            OrdemCompraProdutoBL.GetInstance().VerificarProdutoOc(produtoOc,listaOcProduto);
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

        public List<OrdemCompraDTO> ConsultarOrdemCompraEmitida(string mDt_Inicio, string mDt_Final, int idPessoa)
        {
            this.Mensagem = "";
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();

            listaOrdemCompra = OrdemCompraBL.GetInstance().ConsultarOrdemCompraEmitida(mDt_Inicio, mDt_Final, idPessoa);
            if (OrdemCompraBL.GetInstance().mensagem != "")
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

        public void VerificarProdutoPv(PedidoVendaProdutoDTO pvProduto, List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            this.Mensagem = "";
            PedidoVendaProdutoBL.GetInstance().VerificarProdutoPv(pvProduto,listaPvProduto);
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
