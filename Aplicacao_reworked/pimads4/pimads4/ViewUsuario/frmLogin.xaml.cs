﻿using Controllerpimads4.Controller;
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
            
            UsuarioDTO usuario = new UsuarioDTO();

            usuario.DsLogin = txtDs_Login.Text;
            usuario.DsSenha = txtDs_Senha.Password ;

            estPropriedades.Bl_Logado = false;
            Controller.GetInstance().ValidarLoginUsuario(usuario.DsLogin, usuario.DsSenha);

            if (!estPropriedades.Bl_Logado)
            {
                lblDs_Mensagem.Content = "Login e/ou Senha Inválido(s)";
            }
            else
            {
                this.Close();
            }
        }

        private void BtnLogarAnonimo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
