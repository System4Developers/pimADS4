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
                frmPrincipal.grdFormContentArea.Children.Add(((SubItem)((ListView)sender).SelectedItem).Screen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tela em Construção");
            }
        }
    }
}
