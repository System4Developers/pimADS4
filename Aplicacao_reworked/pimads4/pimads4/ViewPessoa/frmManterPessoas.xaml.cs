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

namespace pimads4.ViewPessoa
{
    /// <summary>
    /// Interação lógica para frmManterPessoas.xam
    /// </summary>
    public partial class frmManterPessoas : UserControl
    {
        public frmManterPessoas()
        {
            InitializeComponent();
            InicializarCampos();
            InicializarBotoes();
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<PessoaDTO> lstPessoa = new List<PessoaDTO>();
            lstPessoa = Controller.GetInstance().ConsultarPessoa();
            dtgPessoas.ItemsSource = lstPessoa;
        }

        private void InicializarCampos()
        {
            txtId_Pessoa.Text = string.Empty;
            cmbTp_Pessoa.SelectedValue = "F";
            txtNm_Pessoa.Text = string.Empty;
            txtNr_Documento.Text = string.Empty;
            txtNr_RG.Text = string.Empty;
            dtpDt_Nascimento.Text = string.Empty;
            txtDs_Email.Text = string.Empty;
            cmbEstado.SelectedValue = null;
            cmbCidade.SelectedValue = null;
            cmbDs_Bairro.SelectedValue = null;
            txtDs_Endereco.Text = string.Empty;
            txtDs_Complemento.Text = string.Empty;
            txtNr_Endereco.Text = string.Empty;

            VerificarTipoPessoa();

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

        private void VerificarTipoPessoa()
        {
            String tipo = "";
            try
            {
                tipo = cmbTp_Pessoa.SelectedValue.ToString();
            }
            catch (Exception)
            {
                tipo = "";
            }

            if (tipo != "" && tipo == "J")
            {
                dtpDt_Nascimento.Text = "";
                dtpDt_Nascimento.IsEnabled = false;
            }
            if (tipo != "" && tipo == "F")
            {
                dtpDt_Nascimento.IsEnabled = true;
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idEstado = Convert.ToInt32(cmbEstado.SelectedValue);

            cmbCidade.ItemsSource = null;
            cmbCidade.ItemsSource = Controller.GetInstance().ConsultarCidadesByEstado(idEstado);
            cmbCidade.SelectedValuePath = "IdCidade";
            cmbCidade.DisplayMemberPath = "NmCidade";
        }

        private void CmbCidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCidade = Convert.ToInt32(cmbCidade.SelectedValue);

            cmbDs_Bairro.ItemsSource = null;
            cmbDs_Bairro.ItemsSource = Controller.GetInstance().ConsultarBairrosByCidade(idCidade);
            cmbDs_Bairro.SelectedValue = "IdBairro";
            cmbDs_Bairro.DisplayMemberPath = "DsBairro";
        }

        private void CmbTp_Pessoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificarTipoPessoa();
        }
    }
}
