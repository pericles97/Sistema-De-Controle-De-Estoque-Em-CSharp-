﻿using Controllers.Controllers;
using Models.Models;
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

namespace ViewWPF.View {
    /// <summary>
    /// Lógica interna para AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window {

        ProdutoController produtoController = new ProdutoController();

        public string codObtido;
        public string codd;

        public AddProduct() {
            InitializeComponent();

            //ProdutoController produtosController = new ProdutoController();
            produtoController.ListarTodos();

            lvDataBinding.ItemsSource = produtoController.ListarTodos();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e) {

            try {
                Produto prod = new Produto();

                prod.Nome = txtNome.Text;
                prod.Codigo = txtCodigo.Text;
                prod.Categoria = txtCategoria.Text;
                prod.Preco = txtPreco.Text;

                if (txtNome.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Nome deve ser preenchido!");
                } else if (txtCodigo.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Codigo deve ser preenchido!");
                } else if (txtCategoria.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Categoria deve ser preenchido!");
                } else if (txtPreco.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Preço deve ser preenchido!");
                } else {

                    ProdutoController produtosController = new ProdutoController();
                    produtosController.Adicionar(prod);
                    MessageBox.Show("Produto salvo com sucesso!");
                }

            } catch (Exception ex) {
                MessageBox.Show("Erro ao salvar o produto (" + ex.Message + ")");
            }
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Close();

        }

        private void BtnCancelProduct_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnListProduct_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {
            try {
                Produto prod = (Produto)lvDataBinding.SelectedItem;
                produtoController.Excluir(prod.ProdutoID);
            } catch (Exception ex) {
                MessageBox.Show("Selecione um Produto");
            }
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Close();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e) {
            Produto prod = (Produto)lvDataBinding.SelectedItem;
            UpdateProduct updateProduct = new UpdateProduct();

            try {

                txtNome.Text = prod.Nome;
                txtCodigo.Text = prod.Codigo;
                txtCategoria.Text = prod.Categoria;
                txtPreco.Text = prod.Preco;
                //codd = txtCodigo.Text;

            } catch (Exception ex) {
                MessageBox.Show("Selecione um Produto para alterar");
            }


        }

        private void ButtonAlterarSalvar_Click(object sender, RoutedEventArgs e) {
            Produto product = (Produto)lvDataBinding.SelectedItem;

            

            //Pegar o preço do produto pelo Codigo
            /*foreach (Produto getCodProduto in produtoController.ListarPorCod(codd)) {
                if (getCodProduto.Codigo != codd.ToString()) {
                    codObtido = getCodProduto.Codigo.ToString();
                    //MessageBox.Show("CPF: "+ getCpf.Cpf.ToString());
                } else if (getCodProduto.Codigo != codd.ToString()) {
                    //MessageBox.Show("CPF: " + txtCpf.Text + "não existe");
                }
            }*/

            try {

                if (txtNome.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Nome deve ser preenchido!");
                } else if (txtCodigo.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Codigo deve ser preenchido!");
                } else if (txtCategoria.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Categoria deve ser preenchido!");
                } else if (txtPreco.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Preço deve ser preenchido!");
                } else {
                    product.Nome = txtNome.Text;
                    product.Codigo = txtCodigo.Text;
                    product.Categoria = txtCategoria.Text;
                    product.Preco = txtPreco.Text;

                    produtoController.Atualizar(product);

                    AddProduct addProduct = new AddProduct();
                    addProduct.Show();
                    this.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Selecione um Produto para alterar");
            }
        }
    }
}
