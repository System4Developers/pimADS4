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
            List<PedidoVendaDTO> listaPedidoVenda = new List<PedidoVendaDTO>();
            listaPedidoVenda = Controller.GetInstance().ConsultarPedidoVendaTodos();
            dtgPedidoVenda.ItemsSource = listaPedidoVenda;
        }

       

        private void DtgPedidoVenda_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dtgPedidoVenda.SelectedIndex >= 0)
            {
                List<PedidoVendaDTO> listaPedidoVenda = new List<PedidoVendaDTO>();
                listaPedidoVenda = dtgPedidoVenda.ItemsSource as List<PedidoVendaDTO>;

                int id_PedidoVenda = listaPedidoVenda[dtgPedidoVenda.SelectedIndex].IdPedido;

                List<PedidoVendaProdutoDTO> listaPvProduto = new List<PedidoVendaProdutoDTO>();
                listaPvProduto = Controller.GetInstance().ConsultarProdutosPorIdPedidoVenda(id_PedidoVenda);
                dtgPedidoVendaProduto.ItemsSource = listaPvProduto;
            }
            
        }
    }
}
