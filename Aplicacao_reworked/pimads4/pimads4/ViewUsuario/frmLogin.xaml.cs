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

namespace pimads4.ViewUsuario
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtDs_Login.Text.Equals("") || txtDs_Senha.Password.Equals(""))
            {
                MessageBox.Show("DIGITE O USUÁRIO E SENHA");
            }
            else
            {
                UsuarioDTO usuario = new UsuarioDTO();
                estPropriedades.Bl_Logado = false;

                usuario.DsLogin = txtDs_Login.Text;
                usuario.DsSenha = txtDs_Senha.Password;

                Controller.GetInstance().ValidarLoginUsuario(usuario.DsLogin, usuario.DsSenha);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }
                if (!estPropriedades.Bl_Logado)
                {
                    lblDs_Mensagem.Content = "LOGIN E/OU SENHA INVÁLIDO(S)";
                }
                else
                {
                    this.Close();
                }
            }
        }


        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            estPropriedades.Bl_Logado = false;
            this.Close();
        }
    }
}
