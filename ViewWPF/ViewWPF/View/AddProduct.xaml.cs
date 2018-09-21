using Controllers.Controllers;
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
        public AddProduct() {
            InitializeComponent();

            ProdutoController produtosController = new ProdutoController();
            produtosController.ListarTodos();

            lvDataBinding.ItemsSource = produtosController.ListarTodos();
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
                    MessageBox.Show("O campo CPF deve ser preenchido!");
                } else if (txtCategoria.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Endereço deve ser preenchido!");
                } else {

                    ProdutoController produtosController = new ProdutoController();
                    produtosController.Adicionar(prod);
                }

                MessageBox.Show("Produto salvo com sucesso!");
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
                ProdutoController produtosController = new ProdutoController();
                produtosController.Excluir(prod.ProdutoID);
            } catch (Exception ex) {
                MessageBox.Show("Selecione um Produto");
            }
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Close();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e) {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.Show();
        }
    }
}
