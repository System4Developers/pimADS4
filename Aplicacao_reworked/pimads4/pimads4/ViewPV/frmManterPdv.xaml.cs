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

            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
            listaPvProduto = dtgPedidoVendaProduto.ItemsSource as List<PedidoVendaProdutoDTO>;
            double vlTotal = Controller.GetInstance().PvProdCalcularValorTotal(listaPvProduto);

            if (Controller.GetInstance().mensagem.Equals(""))
            {
                txtVl_Total.Text = vlTotal.ToString();
            }
            else
            {
                MessageBox.Show(Controller.GetInstance().mensagem);
            }

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
    }
}
