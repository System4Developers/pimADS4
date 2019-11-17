using pimads4.ViewProduto;
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

namespace pimads4.frmPedido
{
    /// <summary>
    /// Interação lógica para frmCadastrarPedido.xam
    /// </summary>
    public partial class frmCadastrarPedido : UserControl
    {
        private frmManterPedido frmManterPedido;

        public frmCadastrarPedido()
        {
            InitializeComponent();
        }

        private void BtnClosePedido_Click(object sender, RoutedEventArgs e)
        {
         
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        private void BtnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Teste Tela1",
                Height = 620,
                Width = 620,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.ToolWindow,
                Content = new frmManterProdutos()
            };
            window.Show();

        }
    }
}
