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
            InicializarCampos();
            InicializarBotoes();
        }

        private void InicializarDtg()
        {
            List<BairroDTO> lstBairros = new List<BairroDTO>();
            lstBairros = Controller.GetInstance().ConsultarBairros();
            dtgBairro.ItemsSource = lstBairros;
        }

        private void InicializarCampos()
        {
            txtId_Bairro.Text = string.Empty;
            txtDs_Bairro.Text = string.Empty;
            cmbEstado.ItemsSource = null;
            cmbEstado.ItemsSource = Controller.GetInstance().ConsultarEstados();
            cmbEstado.SelectedValuePath = "IdEstado";
            cmbEstado.DisplayMemberPath = "DsSigla";
            
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
        
        }

        private void InicializarCmbCidades()
        {
            int idEstado = Convert.ToInt32(cmbEstado.SelectedValue);

            cmbCidade.ItemsSource = null;
            cmbCidade.ItemsSource = Controller.GetInstance().ConsultarCidadesByEstado(idEstado);
            cmbCidade.SelectedValuePath = "IdCidade";
            cmbCidade.DisplayMemberPath = "NmCidade";

        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {

            BairroDTO bairroDtg = (BairroDTO)dtgBairro.SelectedItem;

            BairroDTO bairro = Controller.GetInstance().ConsultarBairroById(bairroDtg.IdBairro);

            txtDs_Bairro.Text = bairro.DsBairro.ToString();
            txtId_Bairro.Text = bairro.IdBairro.ToString();
            cmbEstado.SelectedValue = bairro.Cidade.Estado.IdEstado;
            InicializarCmbCidades();
            cmbCidade.SelectedValue = bairro.Cidade.IdCidade;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;

        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (txtId_Bairro.Text.Equals(""))
            {
                BairroDTO bairro = new BairroDTO();

                bairro.DsBairro = txtDs_Bairro.Text;
                bairro.Cidade.IdCidade = Convert.ToInt32(cmbCidade.SelectedValue);

                Controller.GetInstance().CadastrarBairro(bairro);
                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();

            }
            else
            {
                BairroDTO bairro = new BairroDTO();

                bairro.IdBairro = Convert.ToInt32(txtId_Bairro.Text);
                bairro.DsBairro = txtDs_Bairro.Text;
                bairro.Cidade.IdCidade = Convert.ToInt32(cmbCidade.SelectedValue);

                Controller.GetInstance().AtualizarBairro(bairro);
                InicializarDtg();

            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idBairro;
            idBairro = Convert.ToInt32(txtId_Bairro.Text);

            Controller.GetInstance().ExcluirBairro(idBairro);
            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();

        }

        private void CmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InicializarCmbCidades();
        }
    }
}
