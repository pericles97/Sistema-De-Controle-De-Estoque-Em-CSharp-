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
        ClienteController clientesController = new ClienteController();
        ProdutoController produtoController = new ProdutoController();

        public string cpfObtido;
        public string codObtido;
        public string precoObtido;

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


                string cpff = txtCpf.Text;
                string codd = txtCodigo.Text;

                //clientesController.BuscarPorCPF(cpff);
                //MessageBox.Show("Busca por CPF!"+ clientesController.BuscarPorCPF(cpff).ToString());

                //Pegar o preço do produto pelo Codigo
                foreach (Produto getPrecoProduto in produtoController.ListarPorCod(codd)) {
                    if (getPrecoProduto.Codigo == codd.ToString()) {
                        precoObtido = getPrecoProduto.Preco.ToString();
                        //MessageBox.Show("CPF: "+ getCpf.Cpf.ToString());
                    } else if (getPrecoProduto.Codigo != codd.ToString()) {
                        //MessageBox.Show("CPF: " + txtCpf.Text + "não existe");
                    }
                }

                double qtdParse = Double.Parse(vend.Qtd);
                double preco = Double.Parse(precoObtido);
                double total = qtdParse * preco;
                vend.TotalVenda = total.ToString();

                //Verifica se existe o CPF cadastrado no banco
                foreach (Cliente getCpf in clientesController.ListarPorCpf(cpff)) {
                    if (getCpf.Cpf == cpff.ToString()) {
                        cpfObtido = getCpf.Cpf.ToString();
                        //MessageBox.Show("CPF: "+ getCpf.Cpf.ToString());
                    } else if (getCpf.Cpf != cpff.ToString()) {
                        //MessageBox.Show("CPF: " + txtCpf.Text + "não existe");
                    }
                }

                //Verifica se existe o Codigo do produto cadastrado no banco
                foreach (Produto getProduto in produtoController.ListarPorCod(codd)) {
                    if (getProduto.Codigo == codd.ToString()) {
                        codObtido = getProduto.Codigo.ToString();
                        //MessageBox.Show("CPF: "+ getCpf.Cpf.ToString());
                    } else if (getProduto.Codigo != codd.ToString()) {
                        //MessageBox.Show("CPF: " + txtCpf.Text + "não existe");
                    }
                }

                /*if (cpff.Equals(clientesController.BuscarPorCPF(cpff).ToString())) {
                    MessageBox.Show("Busca por CPF!" + cpff +"Existe");
                }*/

                if (txtCpf.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo CPF deve ser preenchido!");
                } else if (txtCodigo.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Codigo deve ser preenchido!");
                } else if (txtQtd.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Quantidade deve ser preenchido!");
                } else if (cpfObtido != txtCpf.Text) {
                    MessageBox.Show("O CPF " + txtCpf.Text + " não existe");
                } else if (codObtido != txtCodigo.Text) {
                    MessageBox.Show("O Codigo " + txtCodigo.Text + " não existe");
                } else {
                    VendaController vendasController = new VendaController();
                    vendasController.Adicionar(vend);

                    MessageBox.Show("Venda efetuada com sucesso!" +
                        "\n\n" + "O cliente de CFP \"" + txtCpf.Text + "\" realizou uma compra de R$ " + total.ToString("F"));

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

            } catch (Exception ex) {
                MessageBox.Show("Erro ao efetuar a venda (" + ex.Message + ")");
            }
        }
    }
}
