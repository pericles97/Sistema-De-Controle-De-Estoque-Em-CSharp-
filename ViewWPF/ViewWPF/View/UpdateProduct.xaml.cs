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
    /// Lógica interna para UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window {
        public UpdateProduct(int id) {
            InitializeComponent();

            Load_Produto(id);
        }

        public UpdateProduct()
        {
        }

        private void Load_Produto(int id) {

            ProdutoController prodController = new ProdutoController();
            //Produto produto = new Produto();
            Produto produto = prodController.BuscarPorID(id);

            txtNome.Text = produto.Nome;
            txtCodigo.Text = produto.Codigo;
            txtCategoria.Text = produto.Categoria;
            txtPreco.Text = produto.Preco;

        }


        private void BtnUpdateProduct_Click(object sender, RoutedEventArgs e) {
            Produto prod = new Produto();

            prod.Nome = txtNome.Text;
            prod.Codigo = txtCodigo.Text;
            prod.Categoria = txtCategoria.Text;
            prod.Preco = txtPreco.Text;

            ProdutoController prodController = new ProdutoController();
            prodController.Adicionar(prod);
            MessageBox.Show("Produto atualizado com sucesso!");


        }

        private void BtnCancelProduct_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
