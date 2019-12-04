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

namespace pimads4.ViewPC
{
    /// <summary>
    /// Interação lógica para frmManterOc.xam
    /// </summary>
    public partial class frmManterOc : UserControl
    {
        public frmManterOc()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            dtpDt_Digitacao.Text = DateTime.Today.ToString();
            txtNr_Quantidade.Text = string.Empty;
            txtVlr_Custo.Text = string.Empty;
            txtVlr_Total.Text = "0,00";

            CarregarListaFornecedores();
            CarregarListaProdutos();

            dtgProdutos.ItemsSource = null;
        }

        private void AtualizarDatagrid(List<OrdemCompraProdutoDTO> listaOcProduto)
        {
            dtgProdutos.ItemsSource = null;
            dtgProdutos.ItemsSource = listaOcProduto;
        }

        private void AtualizarTotal()
        {

            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;
            double vlTotal = Controller.GetInstance().OcProdCalcularValorTotal(listaOcProduto);


            if (Controller.GetInstance().Mensagem.Equals(""))
            {
                txtVlr_Total.Text = vlTotal.ToString("#0.00");
            }
            else
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }

        }

        private void CarregarListaFornecedores()
        {
            try
            {
                cmbNm_Fornecedor.ItemsSource = Controller.GetInstance().ConsultarPessoaJuridica();
                cmbNm_Fornecedor.SelectedValuePath = "IdPessoa";
                cmbNm_Fornecedor.DisplayMemberPath = "NmPessoa";
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL CARREGAR A LISTA DE FORNECEDORES");
            }
        }
        
        private void CarregarListaProdutos()
        {
            try
            {
                cmbDs_Produto.ItemsSource = Controller.GetInstance().ConsultarProdutos();
                cmbDs_Produto.SelectedValuePath = "IdProduto";
                cmbDs_Produto.DisplayMemberPath = "DsProduto";
            }   
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSIVEL CARREGAR A LISTA DE PRODUTOS");
            }
        }


        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();

            if (dtgProdutos.ItemsSource != null)
            {
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;
            }

            try
            {
                ocProduto.Produto.IdProduto = Convert.ToInt32(cmbDs_Produto.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("PRODUTO NÃO SELECIONADO");
                return;
            }
            try
            {
                ocProduto.VlrUnit = Convert.ToDouble(txtVlr_Custo.Text.Replace('.', ','));
            }
            catch (Exception)
            {
                MessageBox.Show("VALOR DE CUSTO INVÁLIDO");
                return;
            }
            try
            {
                ocProduto.Quantidade = Convert.ToInt32(txtNr_Quantidade.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("VALOR DA QUANTIDADE INVÁLIDO");
                return;
            }

            ocProduto.Produto.DsProduto = cmbDs_Produto.Text;

            Controller.GetInstance().VerificarProdutoOc(ocProduto, listaOcProduto);
            if (Controller.GetInstance().Mensagem.Equals(""))
            {
                listaOcProduto.Add(ocProduto);
                AtualizarDatagrid(listaOcProduto);
                AtualizarTotal();
            }
            else
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }

        }

        private void BtnQtdAdd_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();

            if (dtgProdutos.SelectedIndex >= 0)
            {
                int selIndex = dtgProdutos.SelectedIndex;
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

                Controller.GetInstance().AdicionarQuantidadeProdutoOc(listaOcProduto, selIndex);
                if (Controller.GetInstance().Mensagem.Equals(""))
                {
                    AtualizarDatagrid(listaOcProduto);
                    dtgProdutos.SelectedIndex = selIndex;
                    AtualizarTotal();
                }
                else
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                }
            }
            else
            {
                MessageBox.Show("NENHUM PRODUTO SELECIONADO");
            }
        }

        private void BtnQtdRmv_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

            if (dtgProdutos.SelectedIndex >= 0)
            {
                int selIndex = dtgProdutos.SelectedIndex;
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

                Controller.GetInstance().RemoverQuantidadeProdutoOc(listaOcProduto, dtgProdutos.SelectedIndex);
                if (Controller.GetInstance().Mensagem.Equals(""))
                {
                    AtualizarDatagrid(listaOcProduto);
                    dtgProdutos.SelectedIndex = selIndex;
                    AtualizarTotal();
                }
                else
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                }
            }
            else
            {
                MessageBox.Show("NENHUM PRODUTO SELECIONADO");
            }
        }

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();

            if (dtgProdutos.SelectedIndex >= 0)
            {
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;
                listaOcProduto.RemoveAt(dtgProdutos.SelectedIndex);
                AtualizarDatagrid(listaOcProduto);
                AtualizarTotal();
            }
            else
            {
                MessageBox.Show("NENHUM PRODUTO SELECIONADO");
            }

        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("FINALIZAR ORDEM DE COMPRA?", "FINALIZAR ODC", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }

            OrdemCompraDTO ordemCompra = new OrdemCompraDTO();
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();

            ordemCompra.DtDigitacao = dtpDt_Digitacao.SelectedDate.ToString();
            try
            {
                ordemCompra.ValorTotal = Convert.ToDouble(txtVlr_Total.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VALOR TOTAL INVALIDO");
                return;
            }
            try
            {
                ordemCompra.Pessoa.IdPessoa = Convert.ToInt32(cmbNm_Fornecedor.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("FORNECEDOR NÃO INFORMADO");
                return;
            }
            ordemCompra.TpStatus = "F";
            ordemCompra.Usuario.IdUsuario = estPropriedades.Id_Usuario;
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

            Controller.GetInstance().CadastrarOrdemCompra(ordemCompra,listaOcProduto);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }
            else
            {
                MessageBox.Show("ENTRADA DE PRODUTOS REGISTRADA");
                InicializarCampos();
            }

        }
    }
}
