using Controllerpimads4.Controller;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pimads4
{
    /// <summary>
    /// Interação lógica para frmVendaPdv.xam
    /// </summary>
    public partial class frmManterPdv : UserControl
    {
        public frmManterPdv()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            dtpDt_Digitacao.Text = DateTime.Today.ToString();
            txtNr_Quantidade.Text = string.Empty;
            txtVl_Unitario.Text = string.Empty;

            cmbNm_Cliente.ItemsSource = Controller.GetInstance().ConsultarPessoa();
            cmbNm_Cliente.SelectedValuePath = "IdPessoa";
            cmbNm_Cliente.DisplayMemberPath = "NmPessoa";

            cmbDs_Produto.ItemsSource = Controller.GetInstance().ConsultarProdutos();
            cmbDs_Produto.SelectedValuePath = "IdProduto";
            cmbDs_Produto.DisplayMemberPath = "DsProduto";

            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            dtgPedidoVendaProduto.ItemsSource = listaPvProduto;

        }

        private void AtualizarDatagrid(List<PedidoVendaProdutoDTO> listaPvProduto)
        {
            dtgPedidoVendaProduto.ItemsSource = null;
            dtgPedidoVendaProduto.ItemsSource = listaPvProduto;
        }

        private void AtualizarTotal()
        {
            PedidoVendaDTO pedidoVenda = new PedidoVendaDTO();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();

            listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;

            Controller.GetInstance().PvProdCalcularValorTotal(listaPvProduto, pedidoVenda);
            if (Controller.GetInstance().mensagem.Equals(""))
            {
                txtVl_Total.Text = pedidoVenda.ValorTotal.ToString();
                txtVl_TotalDesconto.Text = pedidoVenda.ValorTotalDesconto.ToString();
            }
            else
            {
                MessageBox.Show(Controller.GetInstance().mensagem);
            }

        }

        private void CmbDs_Produto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ProdutoDTO> listaProduto = new List<ProdutoDTO>();
            listaProduto = cmbDs_Produto.ItemsSource as List<ProdutoDTO>;

            txtVl_Unitario.Text = listaProduto[cmbDs_Produto.SelectedIndex].ValorVenda.ToString();

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;
            try
            {
                pvProduto.Produto.IdProduto = Convert.ToInt32(cmbDs_Produto.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PRODUTO NÃO SELECIONADO");
                return;
            }
            try
            {
                pvProduto.VlrUnit = Convert.ToDouble(txtVl_Unitario.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VALOR UNITARIO INVÁLIDO");
                return;
            }
            try
            {
                pvProduto.Quantidade = Convert.ToInt32(txtNr_Quantidade.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VALOR DE QUANTIDADE INVALIDO");
                return;
            }
            pvProduto.Produto.DsProduto = cmbDs_Produto.Text;
            pvProduto.VlrDesconto = cmbVl_Desconto.SelectedValue.ToString();


            Controller.GetInstance().VerificarProdutoPv(pvProduto);
            if (Controller.GetInstance().mensagem.Equals(""))
            {
                listaPvProduto.Add(pvProduto);
                AtualizarDatagrid(listaPvProduto);
                AtualizarTotal();
            }
            else
            {
                MessageBox.Show(Controller.GetInstance().mensagem);
            }
        }

        private void BtnQtdAdd_Click(object sender, RoutedEventArgs e)
        {
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();

            if (dtgPedidoVendaProduto.SelectedIndex >=0)
            {
                int selIndex = dtgPedidoVendaProduto.SelectedIndex;
                listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;

                Controller.GetInstance().AdicionarQuantidadeProdutoPv(listaPvProduto, selIndex);
                if (Controller.GetInstance().mensagem.Equals(""))
                {
                    AtualizarDatagrid(listaPvProduto);
                    dtgPedidoVendaProduto.SelectedIndex = selIndex;
                    AtualizarTotal();
                }
                else
                {
                    MessageBox.Show(Controller.GetInstance().mensagem);
                }
            }
        }

        private void BtnQtdRmv_Click(object sender, RoutedEventArgs e)
        {
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;

            if (dtgPedidoVendaProduto.SelectedIndex >= 0)
            {
                int selIndex = dtgPedidoVendaProduto.SelectedIndex;
                listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;

                Controller.GetInstance().RemoverQuantidadeProdutoPv(listaPvProduto, selIndex);
                if (Controller.GetInstance().mensagem.Equals(""))
                {
                    AtualizarDatagrid(listaPvProduto);
                    dtgPedidoVendaProduto.SelectedIndex = selIndex;
                    AtualizarTotal();
                }
                else
                {
                    MessageBox.Show(Controller.GetInstance().mensagem);
                }
            }
            else
            {
                MessageBox.Show("NENHUM PRODUTO SELECIONADO");
            }
        }

        private void BtnExluir_Click(object sender, RoutedEventArgs e)
        {
            PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();

            if (dtgPedidoVendaProduto.SelectedIndex >= 0)
            {
                listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;
                listaPvProduto.RemoveAt(dtgPedidoVendaProduto.SelectedIndex);
                AtualizarDatagrid(listaPvProduto);
                AtualizarTotal();
            }
            else
            {
                MessageBox.Show("NENHUM PRODUTO SELECIONADO");
            }
        }

        private void BtnFinalizarVenda_Click(object sender, RoutedEventArgs e)
        {
            int id_PedidoVenda = 0;
            PedidoVendaDTO pedido = new PedidoVendaDTO();

            pedido.DtDigitacao = dtpDt_Digitacao.SelectedDate.ToString();
            try
            {
                pedido.ValorTotal = Convert.ToDouble(txtVl_Total.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VALOR TOTAL INVALIDO");
                return;
            }
            try
            {
                pedido.ValorTotalDesconto = Convert.ToDouble(txtVl_TotalDesconto.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VALOR DO DESCONTO INVALIDO");
                return;
            }
            try
            {
                pedido.Pessoa.IdPessoa = Convert.ToInt32(cmbNm_Cliente.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("CLIENTE NÃO INFORMADO");
                return;
            }
            pedido.TpStatus = "F";
            pedido.Usuario.IdUsuario = estPropriedades.Id_Usuario;
            pedido.TpPagamento = cmbTp_Pagamento.Text;

            id_PedidoVenda = Controller.GetInstance().CadastrarPedidoVenda(pedido);
            if (Controller.GetInstance().mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().mensagem);
            }
            else
            {
                PedidoVendaProdutoDTO pvProduto = new PedidoVendaProdutoDTO();
                List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
                listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;

                Controller.GetInstance().CadastrarProdutoPedidoVenda(listaPvProduto, id_PedidoVenda);
                if (Controller.GetInstance().mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().mensagem);
                }
                else
                {
                    MessageBox.Show("VENDA DE PRODUTOS REGISTRADA");
                }

            }

        }
    }
}
