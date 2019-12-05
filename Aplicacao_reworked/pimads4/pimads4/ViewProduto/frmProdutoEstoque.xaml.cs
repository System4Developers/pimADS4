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
    /// Interação lógica para frmProdutoEstoque.xam
    /// </summary>
    public partial class frmProdutoEstoque : UserControl
    {
        public frmProdutoEstoque()
        {
            InitializeComponent();
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

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
            lstProdutos = Controller.GetInstance().ConsultarProdutoByDs(txtDs_Produto.Text);
            if (Controller.GetInstance().Mensagem!="")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgProdutos.ItemsSource = lstProdutos;
        }
    }
}
