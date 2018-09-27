using Controllers.Controllers;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para AddCliente.xaml
    /// </summary>
    public partial class AddCliente : Window {

        ClienteController clientesController = new ClienteController();

        public AddCliente() {
            InitializeComponent();

            clientesController.ListarTodos();

            lvDataBinding.ItemsSource = clientesController.ListarTodos();

        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e) {

            try {
                Cliente cli = new Cliente();

                cli.Nome = txtNome.Text;
                cli.Cpf = txtCpf.Text;
                cli.Endereco = txtEndereco.Text;

                if (txtNome.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Nome deve ser preenchido!");
                }else if (txtCpf.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo CPF deve ser preenchido!");
                }else if (txtEndereco.Text.Equals(string.Empty)) {
                    MessageBox.Show("O campo Endereço deve ser preenchido!");
                } else {
                    ClienteController clientesController = new ClienteController();
                    clientesController.Adicionar(cli);

                    MessageBox.Show("Cliente salvo com sucesso!");
                }
            } catch (Exception ex) {
                MessageBox.Show("Erro ao salvar o cliente (" + ex.Message + ")");
            }
            AddCliente addCliente = new AddCliente();
            addCliente.Show();//addCliente.UpdateLayout();
            this.Close();
            //custViewSource.View.Refresh();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e) {

            Cliente cli = (Cliente)lvDataBinding.SelectedItem;
            UpdateCliente updateCliente = new UpdateCliente();

            try
            {
                txtNome.Text = cli.Nome;
                txtCpf.Text = cli.Cpf;
                txtEndereco.Text = cli.Endereco;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um cliente para alterar");
            }
                
        }


        private void BtnListClient_Click(object sender, RoutedEventArgs e) {
            Cliente cli = new Cliente();
    
            clientesController.ListarTodos();
            //txtListagem = clientesController.ListarTodos.;

            List<Cliente> items = new List<Cliente>();
            /*items.Add(new Cliente() { Nome = "John Doe"});
            items.Add(new Cliente() { Nome = "Jane Doe" });
            items.Add(new Cliente() { Nome = "Sammy Doe"});*/
            lvDataBinding.ItemsSource = clientesController.ListarTodos();

        }


        private void BtnCancelClient_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {

            try {
                Cliente cli = (Cliente)lvDataBinding.SelectedItem;

                clientesController.Excluir(cli.ClienteID);
            } catch (Exception ex) {
                MessageBox.Show("Selecione um Cliente");
            }

            AddCliente addCliente = new AddCliente();
            addCliente.Show();
            this.Close();
        }

        private void btnAlterarSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = (Cliente)lvDataBinding.SelectedItem;

            try
            {
                cli.Nome = txtNome.Text;
                cli.Cpf = txtCpf.Text;
                cli.Endereco = txtEndereco.Text;

                clientesController.Atualizar(cli);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione um produto para alterar");
            }

            AddCliente addCliente = new AddCliente();
            addCliente.Show();
            this.Close();

        }
    }
}
