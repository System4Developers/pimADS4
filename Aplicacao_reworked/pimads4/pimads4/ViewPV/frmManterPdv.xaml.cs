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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
