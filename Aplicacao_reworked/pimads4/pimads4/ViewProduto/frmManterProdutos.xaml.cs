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

namespace pimads4.ViewProduto
{
    /// <summary>
    /// Interação lógica para frmManterProdutos.xam
    /// </summary>
    public partial class frmManterProdutos : UserControl
    {
        public frmManterProdutos()
        {
            InitializeComponent();
            InicializarCampos();
            InicializarBotoes();
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = Controller.GetInstance().ConsultarProdutos();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgProdutos.ItemsSource = lstProdutos;

        }

        private void InicializarCampos()
        {
            cmbDs_Fabricante.ItemsSource =Controller.GetInstance().ConsultarFabricanteTodos();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            cmbDs_Fabricante.SelectedValuePath = "IdFabricante";
            cmbDs_Fabricante.DisplayMemberPath = "NmFabricante";

            cmbDs_Unidade.ItemsSource =Controller.GetInstance().ConsultarUnidades();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            cmbDs_Unidade.SelectedValuePath = "IdUnidade";
            cmbDs_Unidade.DisplayMemberPath = "DsUnidade";

            cmbTp_Produto.SelectedValue = "V";

            txtId_Produto.Text = string.Empty;
            txtDs_Produto.Text = string.Empty;
            txtVl_Venda.Text = string.Empty;
            txtVl_Custo.Text = string.Empty;
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtId_Produto.Text.Equals(""))
            {
                ProdutoDTO produto = new ProdutoDTO();

                produto.DsProduto = txtDs_Produto.Text;
                produto.ValorVenda = Convert.ToDouble(txtVl_Venda.Text);
                produto.ValorCusto = Convert.ToDouble(txtVl_Custo.Text);
                produto.TpProduto = cmbTp_Produto.SelectedValue.ToString();
                produto.Unidade.IdUnidade = Convert.ToInt32(cmbDs_Unidade.SelectedValue.ToString());
                produto.Fabricante.IdFabricante = Convert.ToInt32(cmbDs_Fabricante.SelectedValue.ToString());

                Controller.GetInstance().CadastrarProduto(produto);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }

                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();
            }
            else
            {
                ProdutoDTO produto = new ProdutoDTO();

                produto.IdProduto = Convert.ToInt32(txtId_Produto.Text);
                produto.DsProduto = txtDs_Produto.Text;
                produto.ValorVenda = Convert.ToDouble(txtVl_Venda.Text);
                produto.ValorCusto = Convert.ToDouble(txtVl_Custo.Text);
                produto.TpProduto = cmbTp_Produto.SelectedValue.ToString();
                produto.Unidade.IdUnidade = Convert.ToInt32(cmbDs_Unidade.SelectedValue.ToString());
                produto.Fabricante.IdFabricante = Convert.ToInt32(cmbDs_Fabricante.SelectedValue.ToString());

                Controller.GetInstance().AtualizarProduto(produto);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }

                InicializarDtg();
            }

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idProduto = Convert.ToInt32(txtId_Produto.Text);
            Controller.GetInstance().ExcluirProduto(idProduto);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
        }

        private void BtnEditar(object sender, RoutedEventArgs e)
        {
            ProdutoDTO produtoDtg = (ProdutoDTO)dtgProdutos.SelectedItem;

            ProdutoDTO produto = Controller.GetInstance().ConsultarProdutoById(produtoDtg.IdProduto);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

            txtId_Produto.Text = produto.IdProduto.ToString();
            txtDs_Produto.Text = produto.DsProduto;
            txtVl_Venda.Text = produto.ValorVenda.ToString();
            txtVl_Custo.Text = produto.ValorCusto.ToString();
            cmbTp_Produto.SelectedValue = produto.TpProduto;
            cmbDs_Unidade.SelectedValue = produto.Unidade.IdUnidade;
            cmbDs_Fabricante.SelectedValue = produto.Fabricante.IdFabricante;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }

    }
}
