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

namespace pimads4.ViewPC
{
    /// <summary>
    /// Interação lógica para frmConsultaPdc.xam
    /// </summary>
    public partial class frmConsultaOc : UserControl
    {
        public frmConsultaOc()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            CarregarDataGridOrdemCompra();
            CarregarListaFornecedores();
            LimparCampos();
        }

        private void CarregarListaFornecedores()
        {
            try
            {
                cmbNm_Fornecedor.ItemsSource = Controller.GetInstance().ConsultarPessoaJuridica();
                cmbNm_Fornecedor.SelectedValuePath = "IdPessoa";
                cmbNm_Fornecedor.DisplayMemberPath = "NmPessoa";
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL CARREGAR A LISTA DE FORNECEDORES");
            }
        }

        private void CarregarDataGridOrdemCompra()
        {
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();

            listaOrdemCompra = Controller.GetInstance().ConsultarOrdemCompraTodos();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgOrdemCompra.ItemsSource = listaOrdemCompra;
        }

        private void LimparCampos()
        {
            dtpDt_Inicial.Text = string.Empty;
            dtpDt_Final.Text = string.Empty;
            cmbNm_Fornecedor.SelectedValue = null;
            txtDs_Fornecedor.Text = string.Empty;
            txtDt_Emissao.Text = string.Empty;
            txtNr_OrdemCompra.Text = string.Empty;
        }

        private void DtgOrdemCompra_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int id_OrdemCompra = 0;
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
            List<OrdemCompraProdutoDTO> listaProdutoOc = new List<OrdemCompraProdutoDTO>();

            if (dtgOrdemCompra.SelectedIndex>=0)
            {
                
                listaOrdemCompra = dtgOrdemCompra.ItemsSource as List<OrdemCompraDTO>;
                try
                {
                    id_OrdemCompra = listaOrdemCompra[dtgOrdemCompra.SelectedIndex].IdOrdemCompra;
                }
                catch (Exception ex)
                {
                    return;
                }
                
                listaProdutoOc = Controller.GetInstance().ConsultarProdutosPorIdOrdemCompra(id_OrdemCompra);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }
                dtgProdutoOc.ItemsSource = listaProdutoOc;
                txtDs_Fornecedor.Text = listaOrdemCompra[dtgOrdemCompra.SelectedIndex].Pessoa.NmPessoa;
                txtDt_Emissao.Text = listaOrdemCompra[dtgOrdemCompra.SelectedIndex].DtDigitacao;
                txtNr_OrdemCompra.Text = listaOrdemCompra[dtgOrdemCompra.SelectedIndex].IdOrdemCompra.ToString();
            }
        }

        private void BtnOc_Consultar_Click(object sender, RoutedEventArgs e)
        {
            int idPessoa=0;
            try
            {
                idPessoa = Convert.ToInt32("0" + cmbNm_Fornecedor.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("FORNECEDOR NÃO SELECIONADO");
            }

            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
            listaOrdemCompra =  Controller.GetInstance().ConsultarOrdemCompraEmitida(dtpDt_Inicial.Text, dtpDt_Final.Text, idPessoa);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }
            else
            {
                dtgOrdemCompra.ItemsSource = listaOrdemCompra;
                dtgProdutoOc.ItemsSource = null;
                txtDs_Fornecedor.Text = string.Empty;
                txtDt_Emissao.Text = string.Empty;
                txtNr_OrdemCompra.Text = string.Empty;

            }
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }
    }
}

