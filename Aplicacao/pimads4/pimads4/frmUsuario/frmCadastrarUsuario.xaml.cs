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

namespace pimads4.frmUsuario
{
    /// <summary>
    /// Interação lógica para frmCadastrarUsuario.xam
    /// </summary>
    public partial class frmCadastrarUsuario : UserControl
    {
        public frmCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            usuario.TpUsuario = cmbTpUsuario.SelectedValue.ToString();
            usuario.DsLogin = txtDsLogin.Text;
            usuario.DsSenha = txtDsSenha.Text;          
            usuario.TpStatus = cmbTpStatus.SelectedValue.ToString();
            

            Controller.GetInstance().CadastrarUsuario(usuario);

        }
    }
}
