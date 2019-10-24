using Controllerpimads4.Controller;
using Modelpimads4.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace pimads4.frmUsuario
{
    /// <summary>
    /// Interação lógica para frmManterUsuarios.xam
    /// </summary>
    public partial class frmManterUsuarios : UserControl
    {
        public frmManterUsuarios()
        {
            InitializeComponent();
            InicializarDtg();
        }

        private void InicializarDtg()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = Controller.GetInstance().ConsultarUsuarios();
            dtgUsuarios.ItemsSource = lstUsuarios;
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Teste Tela",
                Height= 320,
                Width = 320,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.None,
                Content = new frmCadastrarUsuario()
            };
            window.ShowDialog();
            
        }


        private void BtnTeste_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario;
            UsuarioDTO dtv = (UsuarioDTO)dtgUsuarios.SelectedItem;
            MessageBox.Show(dtv.IdUsuario.ToString());


        }
    }
}
