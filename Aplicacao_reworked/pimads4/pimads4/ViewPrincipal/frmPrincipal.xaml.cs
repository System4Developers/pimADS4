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
using pimads4.ViewPrincipal;

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
            lblNm_Usuario.Content ="Usuário: " + estPropriedades.Nm_Usuario + "    Logado em: " + DateTime.Now.ToString("dd/MM/yyyy - H:mm");
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
            List<SubItem> menuInicio = new List<SubItem>();

            ItemMenu itemMenuInicio = null;
            ItemMenu itemMenuPdv = null;
            ItemMenu itemMenuPdc = null;
            ItemMenu itemMenuEntidade = null;
            ItemMenu itemMenuEstoque = null;
            ItemMenu itemMenuEndereco = null;

            grdFormContentArea.Children.Add(new frmPginaInicial());
            lblNm_Form.Content = "Página Inicial";

            menuInicio.Add(new SubItem("Pagina Inicial", "paginaInicial"));
            itemMenuInicio = new ItemMenu("Home", menuInicio, PackIconKind.House);

            menuPdv.Add(new SubItem("Novo", "novoPDV"));
            menuPdv.Add(new SubItem("Consultar", "consultarPDV")); ;
            itemMenuPdv = new ItemMenu("PDV", menuPdv,PackIconKind.ViewDashboard);

            menuPdc.Add(new SubItem("Novo", "novoODC"));
            menuPdc.Add(new SubItem("Consultar","consultarODC"));
            itemMenuPdc = new ItemMenu("ODC", menuPdc, PackIconKind.ViewDashboard);

            menuEntidade.Add(new SubItem("Pessoas" ,"manterPessoas"));
            menuEntidade.Add(new SubItem("Usuarios" ,"manterUsuarios"));
            itemMenuEntidade = new ItemMenu("Entidade", menuEntidade, PackIconKind.Register);

            menuEstoque.Add(new SubItem("Estoque", "estoqueProduto"));
            menuEstoque.Add(new SubItem("Fabricante" , "manterFabricantes"));
            menuEstoque.Add(new SubItem("Produto", "manterProdutos"));
            menuEstoque.Add(new SubItem("Unidade" , "manterUnidades"));
            itemMenuEstoque = new ItemMenu("Estoque", menuEstoque, PackIconKind.FileReport);

            menuEndereco.Add(new SubItem("Cidade" , "manterCidades"));
            menuEndereco.Add(new SubItem("Bairros", "manterBairros"));
            itemMenuEndereco = new ItemMenu("Endereço", menuEndereco, PackIconKind.Earth);

            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuInicio, this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuPdc, this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuPdv,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEntidade,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEstoque,this));
            stpMenuLateral.Children.Add(new UserControlMenuItem(itemMenuEndereco,this));

        }


        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a sessão do usuário?", "Logout Usuário", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {}
            else
            {
                grdFormContentArea.Children.Clear();
                estPropriedades.Bl_Logado = false;

                frmLogin frmLogin = new frmLogin();
                frmLogin.ShowDialog();
                if (!estPropriedades.Bl_Logado)
                {
                    this.Close();
                }
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a Aplicação", "Encerrar Aplicação", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {}
            else
            {
                Application.Current.Shutdown();
            }

        }
    }
}
