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
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e) {

            try {
                Produto prod = new Produto();

                prod.Nome = txtNome.Text;
                prod.Codigo = txtCodigo.Text;
                prod.Categoria = txtCategoria.Text;

                ProdutoController produtosController = new ProdutoController();
                produtosController.Adicionar(prod);

                MessageBox.Show("Produto salvo com sucesso!");
            } catch (Exception ex) {
                MessageBox.Show("Erro ao salvar o produto (" + ex.Message + ")");
            }


            this.Close();

        }

        private void BtnCancelProduct_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
