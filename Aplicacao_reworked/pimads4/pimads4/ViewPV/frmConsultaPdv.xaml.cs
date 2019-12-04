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

namespace pimads4.ViewPV
{
    /// <summary>
    /// Interação lógica para ViewPVConsultar.xam
    /// </summary>
    public partial class frmConsultaPdv : UserControl
    {
        public frmConsultaPdv()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            CarregarDataGridPedidoVenda();
            CarregarListaClientes();
            LimparCampos();
        }

        private void CarregarListaClientes()
        {
            try
            {
                cmbNm_Cliente.ItemsSource = Controller.GetInstance().ConsultarPessoa();
                cmbNm_Cliente.SelectedValuePath = "IdPessoa";
                cmbNm_Cliente.DisplayMemberPath = "NmPessoa";
            }
            catch (Exception)
            {
                MessageBox.Show("NÃO FOI POSSÍVEL CARREGAR A LISTA DE CLIENTES");
            }

        }

        private void CarregarDataGridPedidoVenda()
        {
            List<PedidoVendaDTO> listaPedidoVenda = new List<PedidoVendaDTO>();
            listaPedidoVenda = Controller.GetInstance().ConsultarPedidoVendaTodos();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgPedidoVenda.ItemsSource = listaPedidoVenda;
        }

        private void LimparCampos()
        {
            dtpDt_Inicial.Text = string.Empty;
            dtpDt_Final.Text = string.Empty;
            cmbNm_Cliente.SelectedValue = null;
            txt_Cliente.Text = string.Empty;
            txtDt_Emissao.Text = string.Empty;
            txtNr_PedidoVenda.Text = string.Empty;
        }


        private void DtgPedidoVenda_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int id_PedidoVenda = 0;
            List<PedidoVendaDTO> listaPedidoVenda = new List<PedidoVendaDTO>();
            List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();


            if (dtgPedidoVenda.SelectedIndex >= 0)
            {
                
                listaPedidoVenda = dtgPedidoVenda.ItemsSource as List<PedidoVendaDTO>;
                try
                {
                    id_PedidoVenda = listaPedidoVenda[dtgPedidoVenda.SelectedIndex].IdPedido;
                }
                catch (Exception)
                {
                    return;
                }
                listaPvProduto = Controller.GetInstance().ConsultarProdutosPorIdPedidoVenda(id_PedidoVenda);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }
                dtgPedidoVendaProduto.ItemsSource = listaPvProduto;
                txt_Cliente.Text = listaPedidoVenda[dtgPedidoVenda.SelectedIndex].Pessoa.NmPessoa;
                txtDt_Emissao.Text = listaPedidoVenda[dtgPedidoVenda.SelectedIndex].DtDigitacao;
                txtNr_PedidoVenda.Text = listaPedidoVenda[dtgPedidoVenda.SelectedIndex].IdPedido.ToString();
            }
  
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            
            int idPessoa=0;
            try
            {
                idPessoa = Convert.ToInt32("0" + cmbNm_Cliente.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("FORNECEDOR NÃO SELECIONADO");
            }

            List<PedidoVendaDTO> listaPedidoVenda = new List<PedidoVendaDTO>();
            listaPedidoVenda =  Controller.GetInstance().ConsultarPedidoVendaEmitido(dtpDt_Inicial.Text, dtpDt_Final.Text, idPessoa);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }
            else
            {
                dtgPedidoVenda.ItemsSource = listaPedidoVenda;
                dtgPedidoVendaProduto.ItemsSource = null;
                txt_Cliente.Text = string.Empty;
                txtDt_Emissao.Text = string.Empty;
                txtNr_PedidoVenda.Text = string.Empty;

            }

        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }
    }
}
