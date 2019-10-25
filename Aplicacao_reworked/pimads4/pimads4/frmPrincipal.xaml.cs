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
using pimads4.ViewUsuario;
using pimads4.frmPedido;

namespace pimads4
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {          
            InitializeComponent();
        }

        private void BtnUsuariosConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterUsuarios());
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPedidoConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterPedido());
        }
    }
}
