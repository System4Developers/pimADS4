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

namespace pimads4.ViewUsuario
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
            InicializarCampos();
            InicializarBotoes();
        }

        private void InicializarDtg()
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = Controller.GetInstance().ConsultarUsuarios();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgUsuarios.ItemsSource = lstUsuarios;

        }
        private void InicializarCampos()
        {
            cmbTpUsuario.SelectedValue = "local";
            txtDsLogin.Text = string.Empty;
            txtDsSenha.Password = string.Empty;
            cmbTpStatus.SelectedValue = "S";
            txtNome.Text = string.Empty;
            txtID.Text = string.Empty;
        }

        private void InicializarBotoes()
        {
            btnSalvar.IsEnabled = true;
            btnConsultar.IsEnabled = true;
            btnExcluir.IsEnabled = false;
            btnLimpar.IsEnabled = false;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            List<UsuarioDTO> lstUsuarios = new List<UsuarioDTO>();
            lstUsuarios = Controller.GetInstance().ConsultarUsuarioByNmLogin(txtNome.Text, txtDsLogin.Text);
            if (Controller.GetInstance().Mensagem!="")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }
            dtgUsuarios.ItemsSource = lstUsuarios;
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
            
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (txtID.Text.Equals(""))
            {
                UsuarioDTO usuario = new UsuarioDTO();

                usuario.TpUsuario = cmbTpUsuario.SelectedValue.ToString();
                usuario.DsLogin = txtDsLogin.Text;
                usuario.DsSenha = txtDsSenha.Password;
                usuario.TpStatus = cmbTpStatus.SelectedValue.ToString();
                usuario.NmUsuario = txtNome.Text;

                Controller.GetInstance().CadastrarUsuario(usuario);
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
                UsuarioDTO usuario = new UsuarioDTO();

                usuario.TpUsuario = cmbTpUsuario.SelectedValue.ToString();
                usuario.DsLogin = txtDsLogin.Text;
                usuario.DsSenha = txtDsSenha.Password;
                usuario.TpStatus = cmbTpStatus.SelectedValue.ToString();
                usuario.NmUsuario = txtNome.Text;
                usuario.IdUsuario = Convert.ToInt32(txtID.Text);

                Controller.GetInstance().AtualizarUsuario(usuario);
                if (Controller.GetInstance().Mensagem != "")
                {
                    MessageBox.Show(Controller.GetInstance().Mensagem);
                    return;
                }
                InicializarDtg();

            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario;
            idUsuario = Convert.ToInt32(txtID.Text);

            Controller.GetInstance().ExcluirUsuario(idUsuario);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            InicializarBotoes();
            InicializarCampos();
            InicializarDtg();
            
        }

        private void BtnEditar(object sender, RoutedEventArgs e)
        {
            UsuarioDTO usuarioDtg = (UsuarioDTO)dtgUsuarios.SelectedItem;

            UsuarioDTO usuario = Controller.GetInstance().ConsultarUsuarioById(usuarioDtg.IdUsuario);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

            txtID.Text = usuario.IdUsuario.ToString();
            txtDsSenha.Password = usuario.DsSenha.ToString();
            cmbTpStatus.SelectedValue = usuario.TpStatus;
            cmbTpUsuario.SelectedValue = usuario.TpUsuario;
            txtDsLogin.Text = usuario.DsLogin;
            txtNome.Text = usuario.NmUsuario;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }


    }
}
