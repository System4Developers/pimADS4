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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pimads4.ViewCEP
{
    /// <summary>
    /// Interação lógica para frmManterCidades.xam
    /// </summary>
    public partial class frmManterCidades : UserControl
    {
        public frmManterCidades()
        {
            InitializeComponent();
            InicializarDtg();
            InicializarCampos();
            InicializarBotoes();
        }

        private void InicializarDtg()
        {
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = Controller.GetInstance().ConsultarCidades();
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }
            dtgCidades.ItemsSource = lstCidades;

        }
        private void InicializarCampos()
        {
            cmbEstado.SelectedValue = null;
            cmbEstado.ItemsSource = Controller.GetInstance().ConsultarEstados();
            cmbEstado.SelectedValuePath = "IdEstado";
            cmbEstado.DisplayMemberPath = "DsSigla";
            txtDs_Cidade.Text = string.Empty;
            txtId_Cidade.Text = string.Empty;
            txtCd_Ibge.Text = string.Empty;
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
            List<CidadeDTO> lstCidades = new List<CidadeDTO>();
            lstCidades = Controller.GetInstance().ConsultarCidadeByNm(txtDs_Cidade.Text);
            if (Controller.GetInstance().Mensagem!="")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
            }
            dtgCidades.ItemsSource = lstCidades;
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            btnExcluir.IsEnabled = false;
            InicializarCampos();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            CidadeDTO cidade = new CidadeDTO();
            try
            {
                cidade.Estado.IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("ESTADO NÃO SELECIONADO PARA A CIDADE INFORMADA");
                return;
            }
            cidade.NmCidade = txtDs_Cidade.Text;
            cidade.CodIbge = txtCd_Ibge.Text;

            if (txtId_Cidade.Text.Equals(""))
            {
                Controller.GetInstance().CadastrarCidade(cidade);
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
                try
                {
                    cidade.IdCidade = Convert.ToInt32(txtId_Cidade.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("NENHUMA CIDADE SELECIONADA PARA EDITAR");
                    return;
                }
                Controller.GetInstance().AtualizarCidade(cidade);
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
            int idCidade = Convert.ToInt32(txtId_Cidade.Text);

            Controller.GetInstance().ExcluirCidade(idCidade);
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
            CidadeDTO cidadeDtg = (CidadeDTO)dtgCidades.SelectedItem;

            CidadeDTO cidade = Controller.GetInstance().ConsultarCidadeById(cidadeDtg.IdCidade);
            if (Controller.GetInstance().Mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().Mensagem);
                return;
            }

            txtId_Cidade.Text = cidade.IdCidade.ToString();
            txtDs_Cidade.Text = cidade.NmCidade;
            txtCd_Ibge.Text = cidade.CodIbge;
            cmbEstado.SelectedValue = cidade.Estado.IdEstado;

            btnSalvar.IsEnabled = true;
            btnLimpar.IsEnabled = true;
            btnExcluir.IsEnabled = true;
        }
    }
}
