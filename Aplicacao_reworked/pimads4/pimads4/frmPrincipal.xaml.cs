﻿using System;
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
using pimads4.ViewUsuario;
using pimads4.frmPedido;
using pimads4.ViewProduto;
using pimads4.ViewCEP;

namespace pimads4
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {          
            InitializeComponent();
        }

        private void BtnUsuariosConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterUsuarios());
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPedidoConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterPedido());
        }

        private void BtnFabricantesConsultar_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterFabricantes());
        }

        private void BtnConsultarProdutos_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterProdutos());
        }

        private void BtnConsultarUnidades_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterUnidades());
        }

<<<<<<< HEAD

=======
>>>>>>> 4cd2249acf21a619882f027477b2f643800bbb21
        private void BtnConsultarCidades_Click(object sender, RoutedEventArgs e)
        {
            grdFormContentArea.Children.Clear();
            grdFormContentArea.Children.Add(new frmManterCidades());
        }
<<<<<<< HEAD
        private void Btnlogout_Click(object sender, RoutedEventArgs e)
        {
           
=======

        private void Btnlogout_Click(object sender, RoutedEventArgs e)
        {
>>>>>>> 4cd2249acf21a619882f027477b2f643800bbb21

        }
    }
}
