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
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<FabricanteDTO> lstFabricantes = new List<FabricanteDTO>();
            lstFabricantes = Controller.GetInstance().ConsultarFabricanteTodos();
            dtgFabricantes.ItemsSource = lstFabricantes;

        }

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
                FabricanteDTO fabricante = new FabricanteDTO();

                fabricante.NmFabricante = txtDs_Fabricante.Text;

                Controller.GetInstance().CadastrarFabricante(fabricante);
                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();

            }
            else
            {
                FabricanteDTO fabricante = new FabricanteDTO();

                fabricante.NmFabricante = txtDs_Fabricante.Text;
                fabricante.IdFabricante = Convert.ToInt32(txtId_Fabricante.Text);

                Controller.GetInstance().AtualizarFabricante(fabricante);
                InicializarDtg();

            }
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            FabricanteDTO dtgFabricante = (FabricanteDTO)dtgFabricantes.SelectedItem;

            FabricanteDTO fabricante = Controller.GetInstance().ConsultarFabricanteById(dtgFabricante.IdFabricante);

            txtId_Fabricante.Text = fabricante.IdFabricante.ToString();
            txtDs_Fabricante.Text = fabricante.NmFabricante;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idFabricante;

            idFabricante = Convert.ToInt32(txtId_Fabricante.Text);

            Controller.GetInstance().ExcluirFabricante(idFabricante);

            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
        }


    }
}
