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
            
            txtNr_Endereco.Text = string.Empty;
            txtDs_Observacao.Text = string.Empty;

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

        private void CarregarCmbCidades()
        {
            int idEstado = Convert.ToInt32(cmbEstado.SelectedValue);

            cmbCidade.ItemsSource = null;
            cmbCidade.ItemsSource = Controller.GetInstance().ConsultarCidadesByEstado(idEstado);
            cmbCidade.SelectedValuePath = "IdCidade";
            cmbCidade.DisplayMemberPath = "NmCidade";
        }

        private void CarregarCmbBairros()
        {
            int idCidade = Convert.ToInt32(cmbCidade.SelectedValue);

            cmbDs_Bairro.ItemsSource = null;
            cmbDs_Bairro.ItemsSource = Controller.GetInstance().ConsultarBairrosByCidade(idCidade);
            cmbDs_Bairro.SelectedValuePath = "IdBairro";
            cmbDs_Bairro.DisplayMemberPath = "DsBairro";
        }

        private void CmbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarCmbCidades();
        }

        private void CmbCidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarCmbBairros();
        }

        private void CmbTp_Pessoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VerificarTipoPessoa();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            PessoaDTO pessoa = new PessoaDTO();

            pessoa.IdPessoa = Convert.ToInt32("0"+txtId_Pessoa.Text);
            pessoa.NmPessoa = txtNm_Pessoa.Text;
            pessoa.TpPessoa = cmbTp_Pessoa.SelectedValue.ToString();
            pessoa.NumDocumento = txtNr_Documento.Text;
            pessoa.NumRG = txtNr_RG.Text;
            if (cmbTp_Pessoa.SelectedValue.ToString() == "F")
            {
                pessoa.DtNascimento = dtpDt_Nascimento.Text;
            }
            pessoa.DsEmail = txtDs_Email.Text;
            pessoa.DsEndereco = txtDs_Endereco.Text;
          
            pessoa.NumEnd = txtNr_Endereco.Text;
            pessoa.Observacao = txtDs_Observacao.Text;
            pessoa.Bairro.IdBairro = Convert.ToInt32(cmbDs_Bairro.SelectedValue);

            if (txtId_Pessoa.Text.Equals(""))
            {
                Controller.GetInstance().CadastrarPessoa(pessoa);

                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();
            }
            else
            {
                pessoa.IdPessoa = Convert.ToInt32(txtId_Pessoa.Text);
                Controller.GetInstance().AtualizarPessoa(pessoa);

                InicializarDtg();
            }

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idPessoa = Convert.ToInt32(txtId_Pessoa.Text);
            Controller.GetInstance().ExcluirPessoa(idPessoa);

            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
        }

        private void BtnEditar(object sender, RoutedEventArgs e)
        {
            PessoaDTO pessoaDtg = (PessoaDTO)dtgPessoas.SelectedItem;

            PessoaDTO pessoa = Controller.GetInstance().ConsultarPessoaById(pessoaDtg.IdPessoa);

            txtId_Pessoa.Text = pessoa.IdPessoa.ToString();
            txtNm_Pessoa.Text = pessoa.NmPessoa;
            cmbTp_Pessoa.SelectedValue = pessoa.TpPessoa;
            txtNr_Documento.Text = pessoa.NumDocumento;
            txtNr_RG.Text = pessoa.NumRG;
            if (pessoa.TpPessoa == "F")
            {
                dtpDt_Nascimento.Text = pessoa.DtNascimento;
            }
            txtDs_Email.Text = pessoa.DsEmail;
            txtDs_Endereco.Text = pessoa.DsEndereco;
            
            txtNr_Endereco.Text = pessoa.NumEnd;
            txtDs_Observacao.Text = pessoa.Observacao;

            cmbEstado.SelectedValue = pessoa.Bairro.Cidade.Estado.IdEstado;
            CarregarCmbCidades();

            cmbCidade.SelectedValue = pessoa.Bairro.Cidade.IdCidade;
            CarregarCmbBairros();

            cmbDs_Bairro.SelectedValue = pessoa.Bairro.IdBairro;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }

    }
}
