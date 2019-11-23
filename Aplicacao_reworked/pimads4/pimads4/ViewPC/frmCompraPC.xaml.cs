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

namespace pimads4.ViewPC
{
    /// <summary>
    /// Interação lógica para frmCompraPC.xam
    /// </summary>
    public partial class frmCompraPC : UserControl
    {
        public frmCompraPC()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            dtpDt_Digitacao.Text = DateTime.Today.ToString();
            txtNr_Quantidade.Text = string.Empty;
            txtVlr_Custo.Text = string.Empty;

            cmbNm_Fornecedor.ItemsSource = Controller.GetInstance().ConsultarPessoaJuridica();
            cmbNm_Fornecedor.SelectedValuePath = "IdPessoa";
            cmbNm_Fornecedor.DisplayMemberPath = "NmPessoa";

            cmbDs_Produto.ItemsSource = Controller.GetInstance().ConsultarProdutos(); 
            cmbDs_Produto.SelectedValuePath = "IdProduto";
            cmbDs_Produto.DisplayMemberPath = "DsProduto";

            List<OrdemCompraProdutoDTO> listaOcProdutos = new List<OrdemCompraProdutoDTO>();
            dtgProdutos.ItemsSource = listaOcProdutos;

        }

        private void AtualizarDatagrid(List<OrdemCompraProdutoDTO> listaOcProduto)
        {
            dtgProdutos.ItemsSource = null;
            dtgProdutos.ItemsSource = listaOcProduto;
        }

        private void AtualizarTotal()
        {/*
            Double vlTotal = 0;
            List<ProdutoDTO> lista = new List<ProdutoDTO>();
            lista = dtgProdutos.ItemsSource as List<ProdutoDTO>;
            try
            {
                foreach (ProdutoDTO p in lista)
                {
                    vlTotal += p.SubTotal1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao foi possivel calcular o total");
            }
            txtTotal.Text = vlTotal.ToString();*/

        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

            try
            {
                ocProduto.Produto.IdProduto = Convert.ToInt32(cmbDs_Produto.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("PRODUTO NÃO SELECIONADO");
                return;
            }
            try
            {
                ocProduto.VlrUnit = Convert.ToDouble(txtVlr_Custo.Text.Replace('.', ','));
            }
            catch (Exception)
            {
                MessageBox.Show("VALOR DE CUSTO INVÁLIDO");
                return;
            }
            try
            {
                ocProduto.Quantidade = Convert.ToInt32(txtNr_Quantidade.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("VALOR DA QUANTIDADE INVÁLIDO");
                return;
            }

            ocProduto.Produto.DsProduto = cmbDs_Produto.Text;
            
            Controller.GetInstance().VerificarProdutoOc(ocProduto);
            if (Controller.GetInstance().mensagem != "")
            {
                MessageBox.Show(Controller.GetInstance().mensagem);
            }
            else
            {
                listaOcProduto.Add(ocProduto);
                AtualizarDatagrid(listaOcProduto);
            }
        }

        private void BtnProdRemover_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            if (dtgProdutos.SelectedIndex >= 0)
            {
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;
                listaOcProduto.RemoveAt(dtgProdutos.SelectedIndex);
                AtualizarDatagrid(listaOcProduto);
            }
        }

        private void BtnQtdAdd_Click(object sender, RoutedEventArgs e)
        {
            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();

            if (dtgProdutos.SelectedIndex >= 0)
            {
                int selIndex = dtgProdutos.SelectedIndex;
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

                Controller.GetInstance().AdicionarQuantidadeProdutoOc(listaOcProduto, dtgProdutos.SelectedIndex);
                
                AtualizarDatagrid(listaOcProduto);
                dtgProdutos.SelectedIndex = selIndex;
            }
        }

        private void BtnQtdRemover_Click(object sender, RoutedEventArgs e)
        {

            OrdemCompraProdutoDTO ocProduto = new OrdemCompraProdutoDTO();
            List<OrdemCompraProdutoDTO> listaOcProduto = new List<OrdemCompraProdutoDTO>();
            listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

            if (dtgProdutos.SelectedIndex >= 0)
            {
                int selIndex = dtgProdutos.SelectedIndex;
                listaOcProduto = dtgProdutos.ItemsSource as List<OrdemCompraProdutoDTO>;

                listaOcProduto = Controller.GetInstance().RemoverQuantidadeProdutoOc(listaOcProduto, dtgProdutos.SelectedIndex);

                if (Controller.GetInstance().mensagem.Equals(""))
                {
                    AtualizarDatagrid(listaOcProduto);
                    dtgProdutos.SelectedIndex = selIndex;
                }
                else
                {
                    MessageBox.Show(Controller.GetInstance().mensagem);
                }
            }
        }

    }
}
