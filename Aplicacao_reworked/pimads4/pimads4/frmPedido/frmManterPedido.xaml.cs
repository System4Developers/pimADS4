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

namespace pimads4.frmPedido
{
    /// <summary>
    /// Interação lógica para frmManterPedido.xam
    /// </summary>
    public partial class frmManterPedido : UserControl
    {
        public frmManterPedido()
        {
            InitializeComponent();
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<PedidoDTO> lstPedidos = new List<PedidoDTO>();
            lstPedidos = Controller.GetInstance().ConsultarPedidos();
            dtgPedidos.ItemsSource = lstPedidos;

        }

        private void BtnNovoPedido_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Teste Tela",
                Height = 620,
                Width = 620,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.None,
                Content = new frmCadastrarPedido()
            };
            window.ShowDialog();
        }
    }
}
