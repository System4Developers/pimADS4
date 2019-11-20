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
using MaterialDesignThemes.Wpf;

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



            var menuPdv = new List<SubItem>();
            menuPdv.Add(new SubItem("Novo"));
            menuPdv.Add(new SubItem("Consultar"));
            var item6 = new ItemMenu("PDV", menuPdv,PackIconKind.Schedule);

            var menuPdc = new List<SubItem>();
            menuPdc.Add(new SubItem("Novo"));
            menuPdc.Add(new SubItem("Consultar"));
            var item0 = new ItemMenu("PDC", menuPdc, PackIconKind.Schedule);

            var menuRegistro = new List<SubItem>();
            menuRegistro.Add(new SubItem("Pessoas" ));
            menuRegistro.Add(new SubItem("Usuarios" ));
            var item1 = new ItemMenu("Entidade", menuRegistro, PackIconKind.Register);



            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Estoque"));
            menuReports.Add(new SubItem("Fabricante"));
            menuReports.Add(new SubItem("Pedido"));
            menuReports.Add(new SubItem("Produto"));
            menuReports.Add(new SubItem("Unidade"));
            var item2 = new ItemMenu("Estoque", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Cidade"));
            menuExpenses.Add(new SubItem("Bairros"));
            var item3 = new ItemMenu("Endereço", menuExpenses, PackIconKind.ShoppingBasket);



            Menu.Children.Add(new UserControlMenuItem(item0));
            Menu.Children.Add(new UserControlMenuItem(item6));
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));
            Menu.Children.Add(new UserControlMenuItem(item3));




            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!estPropriedades.Bl_Logado)
            {
                this.Close();
            }
            //lblNm_Usuario.Content ="Usuário: " + estPropriedades.Nm_Usuario;
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
            estPropriedades.Bl_Logado = false;
            novo.ShowDialog();
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
