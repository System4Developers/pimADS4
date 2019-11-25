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
using pimads4.ViewPC;
using pimads4.ViewPV;

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
            List<SubItem> menuPdv = new List<SubItem>();
            List<SubItem> menuPdc = new List<SubItem>();
            List<SubItem> menuEntidade = new List<SubItem>();
            List<SubItem> menuEstoque = new List<SubItem>();
            List<SubItem> menuEndereco = new List<SubItem>();
            ItemMenu itemMenuPdv = null;
            ItemMenu itemMenuPdc = null;
            ItemMenu itemMenuEntidade = null;
            ItemMenu itemMenuEstoque = null;
            ItemMenu itemMenuEndereco = null;

            menuPdv.Add(new SubItem("Novo", new frmVendaPdv()));
            menuPdv.Add(new SubItem("Consultar", new ViewPVConsultar())); ;
            itemMenuPdv = new ItemMenu("PDV", menuPdv,PackIconKind.ViewDashboard);

            menuPdc.Add(new SubItem("Novo", new frmComprarPdc()));
            menuPdc.Add(new SubItem("Consultar"));
            itemMenuPdc = new ItemMenu("PDC", menuPdc, PackIconKind.ViewDashboard);

            menuEntidade.Add(new SubItem("Pessoas" ,new frmManterPessoas()));
            menuEntidade.Add(new SubItem("Usuarios" , new frmManterUsuarios() ));
            itemMenuEntidade = new ItemMenu("Entidade", menuEntidade, PackIconKind.Register);

            menuEstoque.Add(new SubItem("Estoque"));
            menuEstoque.Add(new SubItem("Fabricante" , new frmManterFabricantes()));
            menuEstoque.Add(new SubItem("Produto", new frmManterProdutos()));
            menuEstoque.Add(new SubItem("Unidade" ,new frmManterUnidades()));
            itemMenuEstoque = new ItemMenu("Estoque", menuEstoque, PackIconKind.FileReport);

            menuEndereco.Add(new SubItem("Cidade" , new frmManterCidades()));
            menuEndereco.Add(new SubItem("Bairros", new frmManterBairros()));
            itemMenuEndereco = new ItemMenu("Endereço", menuEndereco, PackIconKind.Earth);

            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuPdc, this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuPdv,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEntidade,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEstoque,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEndereco,this));

        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
   
    }
}
