using pimads4.ViewCEP;
using pimads4.ViewPC;
using pimads4.ViewPessoa;
using pimads4.ViewProduto;
using pimads4.ViewPV;
using pimads4.ViewUsuario;
using System;
using System.Collections.Generic;
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

namespace pimads4
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        private MainWindow frmPrincipal;

        public UserControlMenuItem(ItemMenu itemMenu, MainWindow frmPrincipal)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.frmPrincipal = frmPrincipal;
            this.DataContext = itemMenu;
        }
  
        private void ListViewMenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                frmPrincipal.grdFormContentArea.Children.Clear();
                
                switch (((SubItem)((ListView)sender).SelectedItem).MenuTela)
                {
                    case "novoPDV":
                        frmPrincipal.grdFormContentArea.Children.Add( new frmManterPdv());
                        break;
                    case "consultarPDV":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmConsultaPdv());
                        break;
                    case "novoODC":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterOc());
                        break;
                    case "consultarODC":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmConsultaOc());
                        break;
                    case "manterPessoas":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterPessoas());
                        break;
                    case "manterUsuarios":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterUsuarios());
                        break;
                    case "estoqueProduto":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmProdutoEstoque());
                        break;
                    case "manterFabricantes":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterFabricantes());
                        break;
                    case "manterProdutos":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterProdutos());
                        break;
                    case "manterUnidades":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterUnidades());
                        break;
                    case "manterCidades":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterCidades());
                        break;
                    case "manterBairros":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterBairros());
                        break;
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tela em Construção");
            }
        }
    }
}
