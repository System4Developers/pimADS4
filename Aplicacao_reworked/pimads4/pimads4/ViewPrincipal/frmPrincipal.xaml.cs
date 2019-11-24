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
            // Login manter sequencia
            InitializeComponent();
            InicializarLogin();
            // Login manter sequencia

            InicializarMenuLateral();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!estPropriedades.Bl_Logado)
            {
                this.Close();
            }
            //lblNm_Usuario.Content ="Usuário: " + estPropriedades.Nm_Usuario;
        }

        private void InicializarLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void InicializarMenuLateral()
        {
                
            var menuPdv = new List<SubItem>();
            menuPdv.Add(new SubItem("Novo", new frmVendaPdv()));
            menuPdv.Add(new SubItem("Consultar", new ()));
            var itemMenuPDV = new ItemMenu("PDV", menuPdv,PackIconKind.ViewDashboard);

            var menuPdc = new List<SubItem>();
            menuPdc.Add(new SubItem("Novo"));
            menuPdc.Add(new SubItem("Consultar"));
            var item0 = new ItemMenu("PDC", menuPdc, PackIconKind.ViewDashboard);

            var menuRegistro = new List<SubItem>();
            menuRegistro.Add(new SubItem("Pessoas" ,new frmManterPessoas()));
            menuRegistro.Add(new SubItem("Usuarios" , new frmManterUsuarios() ));
            var item1 = new ItemMenu("Entidade", menuRegistro, PackIconKind.Register);

            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Estoque"));
            menuReports.Add(new SubItem("Fabricante" , new frmManterFabricantes()));
            menuReports.Add(new SubItem("Produto", new frmManterProdutos()));
            menuReports.Add(new SubItem("Unidade" ,new frmManterUnidades()));
            var item2 = new ItemMenu("Estoque", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Cidade" , new frmManterCidades()));
            menuExpenses.Add(new SubItem("Bairros", new frmManterBairros()));
            var item3 = new ItemMenu("Endereço", menuExpenses, PackIconKind.Earth);

            Menu.Children.Add(new UserControlMenuItem(item0,this));
            Menu.Children.Add(new UserControlMenuItem(itemMenuPDV,this));
            Menu.Children.Add(new UserControlMenuItem(item1,this));
            Menu.Children.Add(new UserControlMenuItem(item2,this));
            Menu.Children.Add(new UserControlMenuItem(item3,this));

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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

   
    }
}
