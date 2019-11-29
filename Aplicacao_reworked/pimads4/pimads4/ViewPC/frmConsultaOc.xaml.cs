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
            List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
            listaOrdemCompra = Controller.GetInstance().ConsultarOrdemCompraTodos();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgOrdemCompra.ItemsSource = listaOrdemCompra;
        }

        private void DtgOrdemCompra_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dtgOrdemCompra.SelectedIndex>=0)
            {
                List<OrdemCompraDTO> listaOrdemCompra = new List<OrdemCompraDTO>();
                listaOrdemCompra = dtgOrdemCompra.ItemsSource as List<OrdemCompraDTO>;

                int id_OrdemCompra = listaOrdemCompra[dtgOrdemCompra.SelectedIndex].IdOrdemCompra;

                List<OrdemCompraProdutoDTO> listaProdutoOc = new List<OrdemCompraProdutoDTO>();
                listaProdutoOc = Controller.GetInstance().ConsultarProdutosPorIdOrdemCompra(id_OrdemCompra);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }
                dtgProdutoOc.ItemsSource = listaProdutoOc;
            }
        }
    }
}

