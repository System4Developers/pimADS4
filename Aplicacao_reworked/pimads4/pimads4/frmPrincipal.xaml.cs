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
using pimads4.ViewProduto;
using pimads4.ViewCEP;
using pimads4.ViewPessoa;
using Modelpimads4.DTO;

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
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblNm_Usuario.Content ="Usuário: " + estPropriedades.Nm_Usuario;
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

        private void BtnFabricantesConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterFabricantes());
        }

        private void BtnConsultarProdutos_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterProdutos());
        }

        private void BtnConsultarUnidades_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterUnidades());
        }
        private void BtnConsultarCidades_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterCidades());
        }
        private void Btnlogout_Click(object sender, RoutedEventArgs e)
        {
            frmLogin novo = new frmLogin();
            novo.Show();
        }

        private void BtnConsultarBairro_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterBairros());
        }

        private void BtnConsultarOc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConsultarPessoas_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterPessoas());
        }


    }
}
