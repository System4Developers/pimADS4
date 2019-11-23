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
    /// Interação lógica para frmCompraPC.xam
    /// </summary>
    public partial class frmCompraPC : UserControl
    {
        public frmCompraPC()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            dtpDt_Digitacao.Text = DateTime.Today.ToString();
            txtNr_Quantidade.Text = string.Empty;
            txtVlr_Custo.Text = string.Empty;

            cmbNm_Fornecedor.ItemsSource = Controller.GetInstance().ConsultarPessoaJuridica();
            cmbNm_Fornecedor.SelectedValuePath = "IdPessoa";
            cmbNm_Fornecedor.DisplayMemberPath = "NmPessoa";

            cmbDs_Produto.ItemsSource = Controller.GetInstance().ConsultarProdutos(); 
            cmbDs_Produto.SelectedValuePath = "IdProduto";
            cmbDs_Produto.DisplayMemberPath = "DsProduto";

            List<OrdemCompraProdutoDTO> listaOcProdutos = new List<OrdemCompraProdutoDTO>();
            dtgProdutos.ItemsSource = listaOcProdutos;

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

            try
            {
                ocProduto.Produto.IdProduto = Convert.ToInt32(cmbDs_Produto.SelectedValue);
                ocProduto.VlrUnit = Convert.ToDouble(txtVlr_Custo.Text.Replace('.', ','));
                ocProduto.Quantidade = Convert.ToInt32(txtNr_Quantidade.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tipo de dado inválido");
            }
            ocProduto.Produto.DsProduto = cmbDs_Produto.Text;
            ocProduto.SubTotal = ocProduto.Quantidade * ocProduto.VlrUnit;

            listaOcProduto.Add(ocProduto);

            dtgProdutos.ItemsSource = null;
            dtgProdutos.ItemsSource = listaOcProduto;
                       
        }
    }
}
