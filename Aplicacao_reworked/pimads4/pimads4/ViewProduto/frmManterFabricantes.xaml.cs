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

namespace pimads4.ViewProduto
{
    /// <summary>
    /// Interação lógica para frmManterFabricantes.xam
    /// </summary>
    public partial class frmManterFabricantes : UserControl
    {
        public frmManterFabricantes()
        {
            InitializeComponent();
            InicializarCampos();
            InicializarBotoes();
        }

        /*      private void InicializarDtg()
                {
                    List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
                    lstUsuarios = Controller.GetInstance().ConsultarUsuarios();
                    dtgUsuarios.ItemsSource = lstUsuarios;

                }*/

        private void InicializarCampos()
        {
            txtId_Fabricante.Text = string.Empty;
            txtDs_Fabricante.Text = string.Empty;
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtId_Fabricante.Text.Equals(""))
            {
                InicializarBotoes();
                InicializarCampos();
                //InicializarDtg();
            }
            else
            {
                //InicializarDtg();
            }

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            InicializarBotoes();
            InicializarCampos();
            //InicializarDtg();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
        }

        private void BtnConsultar_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
