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
using System.Windows.Shapes;

namespace pimads4.frmLogin
{
    /// <summary>
    /// Lógica interna para frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnAcessar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();

            usuario.DsLogin = txtDsLogin.Text;
            usuario.DsSenha = txtDsSenha.Password;


            
        }
    }
}
