using pimads4.ViewCEP;
using pimads4.ViewPC;
using pimads4.ViewPessoa;
using pimads4.ViewPrincipal;
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
                frmPrincipal.lblNm_Form.Content = "";

                switch (((SubItem)((ListView)sender).SelectedItem).MenuTela)
                {
                    case "novoPDV":
                        frmPrincipal.grdFormContentArea.Children.Add( new frmManterPdv());
                        frmPrincipal.lblNm_Form.Content = "PEDIDO DE VENDA";
                        break;
                    case "consultarPDV":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmConsultaPdv());
                        frmPrincipal.lblNm_Form.Content = "PEDIDOS DE VENDA EMITIDOS";
                        break;
                    case "novoODC":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterOc());
                        frmPrincipal.lblNm_Form.Content = "ORDEM DE COMPRA";
                        break;
                    case "consultarODC":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmConsultaOc());
                        frmPrincipal.lblNm_Form.Content = "ORDENS DE COMPRA EMITIDAS";
                        break;
                    case "manterPessoas":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterPessoas());
                        frmPrincipal.lblNm_Form.Content = "CLIENTES/FORNECEDORES";
                        break;
                    case "manterUsuarios":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterUsuarios());
                        frmPrincipal.lblNm_Form.Content = "USUÁRIOS";
                        break;
                    case "estoqueProduto":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmProdutoEstoque());
                        frmPrincipal.lblNm_Form.Content = "ESTOQUE - PRODUTOS";
                        break;
                    case "manterFabricantes":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterFabricantes());
                        frmPrincipal.lblNm_Form.Content = "FABRICANTES";
                        break;
                    case "manterProdutos":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterProdutos());
                        frmPrincipal.lblNm_Form.Content = "PRODUTOS";
                        break;
                    case "manterUnidades":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterUnidades());
                        frmPrincipal.lblNm_Form.Content = "UNIDADES";
                        break;
                    case "manterCidades":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterCidades());
                        frmPrincipal.lblNm_Form.Content = "CIDADES";
                        break;
                    case "manterBairros":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmManterBairros());
                        frmPrincipal.lblNm_Form.Content = "BAIRROS";
                        break;
                    case "paginaInicial":
                        frmPrincipal.grdFormContentArea.Children.Add(new frmPginaInicial());
                        frmPrincipal.lblNm_Form.Content = "Página Inicial";
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
