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
    /// Interação lógica para frmManterCidades.xam
    /// </summary>
    public partial class frmManterCidades : UserControl
    {
        public frmManterCidades()
        {
            InitializeComponent();
            InicializarDtg();
            InicializarCampos();
            InicializarBotoes();
        }

        private void InicializarDtg()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = Controller.GetInstance().ConsultarCidades();
            dtgCidades.ItemsSource = lstCidades;

        }
        private void InicializarCampos()
        {
            cmbEstado.SelectedValue = null;
            cmbEstado.ItemsSource = Controller.GetInstance().ConsultarEstados();
            cmbEstado.SelectedValuePath = "IdEstado";
            cmbEstado.DisplayMemberPath = "DsSigla";
            txtDs_Cidade.Text = string.Empty;
            txtId_Cidade.Text = string.Empty;
            txtCd_Ibge.Text = string.Empty;
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {

            CidadeDTO cidadeDtg = (CidadeDTO)dtgCidades.SelectedItem;

            CidadeDTO cidade = Controller.GetInstance().ConsultarCidadeById(cidadeDtg.IdCidade);

            txtId_Cidade.Text = cidade.IdCidade.ToString();
            txtDs_Cidade.Text = cidade.NmCidade;
            txtCd_Ibge.Text = cidade.CodIbge;
            cmbEstado.SelectedValue = cidade.Estado.IdEstado;

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

            if (txtId_Cidade.Text.Equals(""))
            {
                CidadeDTO cidade = new CidadeDTO();

                cidade.NmCidade = txtDs_Cidade.Text;
                cidade.CodIbge = txtCd_Ibge.Text;
                cidade.Estado.IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);

                Controller.GetInstance().CadastrarCidade(cidade);
                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();

            }
            else
            {
                CidadeDTO cidade = new CidadeDTO();

                cidade.IdCidade = Convert.ToInt32(txtId_Cidade.Text);
                cidade.NmCidade = txtDs_Cidade.Text;
                cidade.CodIbge = txtCd_Ibge.Text;
                cidade.Estado.IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);

                Controller.GetInstance().AtualizarCidade(cidade);
                InicializarDtg();

            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idCidade = Convert.ToInt32(txtId_Cidade.Text);

            Controller.GetInstance().ExcluirCidade(idCidade);
            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();

        }
    }
}
