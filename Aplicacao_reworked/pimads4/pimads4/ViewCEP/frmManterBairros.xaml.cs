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

namespace pimads4.ViewCEP
{
    /// <summary>
    /// Interação lógica para frmManterBairros.xam
    /// </summary>
    public partial class frmManterBairros : UserControl
    {
        public frmManterBairros()
        {
            InitializeComponent();
            InicializarDtg();
            InicializarBotoes();
        }

        private void InicializarDtg()
        {
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = Controller.GetInstance().ConsultarBairros();
            dtgBairro.ItemsSource = lstBairros;
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
            this.cmbEstado.ItemsSource = Controller.GetInstance().ConsultarCidades();
            this.cmbEstado.DisplayMemberPath = "Nome";
            this.cmbEstado.SelectedValuePath = "IdCidade";
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
      
        }
    }
}
