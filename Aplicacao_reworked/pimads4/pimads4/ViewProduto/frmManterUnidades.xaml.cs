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
    /// Interação lógica para frmManterUnidades.xam
    /// </summary>
    public partial class frmManterUnidades : UserControl
    {
        public frmManterUnidades()
        {
            InitializeComponent();
            InicializarCampos();
            InicializarBotoes();
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<UnidadeDTO> lstUnidades = new List<UnidadeDTO>();
            lstUnidades = Controller.GetInstance().ConsultarUnidades();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgUnidades.ItemsSource = lstUnidades;

        }

        private void InicializarCampos()
        {
            txtId_Unidade.Text = string.Empty;
            txtDs_Unidade.Text = string.Empty;
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
            if (txtId_Unidade.Text.Equals(""))
            {
                UnidadeDTO unidade = new UnidadeDTO();
                unidade.DsUnidade = txtDs_Unidade.Text;
                Controller.GetInstance().CadastarUnidade(unidade);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }

                InicializarBotoes();
                InicializarCampos();
                InicializarDtg();
            }
            else
            {
                UnidadeDTO unidade = new UnidadeDTO();
                unidade.IdUnidade = Convert.ToInt32(txtId_Unidade.Text);
                unidade.DsUnidade = txtDs_Unidade.Text;

                Controller.GetInstance().AtualizarUnidade(unidade);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }

                InicializarDtg();
            }

        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idUnidade = Convert.ToInt32(txtId_Unidade.Text);
            Controller.GetInstance().ExcluirUnidade(idUnidade);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

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
            UnidadeDTO unidadeDtg = (UnidadeDTO)dtgUnidades.SelectedItem;

            UnidadeDTO unidade = Controller.GetInstance().ConsultarUnidadeById(unidadeDtg.IdUnidade);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

            txtId_Unidade.Text = unidade.IdUnidade.ToString();
            txtDs_Unidade.Text = unidade.DsUnidade.ToString();

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }
    }
}
