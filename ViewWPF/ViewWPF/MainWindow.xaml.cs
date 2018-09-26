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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewWPF.View;

namespace ViewWPF {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            VendaController vendasController = new VendaController();
            vendasController.ListarTodos();


        }
        /**
         * 
         * https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/database-first
         * 
         * **/


        private void BtnCadClient_Click(object sender, RoutedEventArgs e) {
            AddCliente addCliente = new AddCliente();
            addCliente.Show();
            this.Close();
        }

        private void BtnCadProduct_Click(object sender, RoutedEventArgs e) {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Close();
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e) {
            /*ClienteController clientesController = new ClienteController();
            clientesController.ListarTodos();

            string sql = "SELECT Cpf from Cliente WHERE Cpf=@Cpf";

            Cliente cliente = new Cliente();
            cliente.Cpf = 
            string CpfDB = clientesController.BuscarPorCPF(cpf);*/

            /*var ClientesComNome = from cli in contexto.Clientes
                        where cli.Nome.ToLower() == nome.ToLower()
                        select cli;*/

            /*ProdutoController produtosController = new ProdutoController();
            string ProdDB = produtosController.BuscarPorCOD();*/


            try {
                Venda vend = new Venda();

                vend.Cpf = txtCpf.Text;
                vend.Codigo = txtCodigo.Text;
                vend.Qtd = txtQtd.Text;

                if (true) {

                }

                if (txtCpf.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo CPF deve ser preenchido!");
                } else if (txtCodigo.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Codigo deve ser preenchido!");
                } else if (txtQtd.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Quantidade deve ser preenchido!");
                } else {
                    VendaController vendasController = new VendaController();
                    vendasController.Adicionar(vend);

                    MessageBox.Show("Venda evetuada com sucesso!");
                }
            } catch (Exception ex) {
                MessageBox.Show("Erro ao efetuar a venda (" + ex.Message + ")");
            }


        }
    }
}
