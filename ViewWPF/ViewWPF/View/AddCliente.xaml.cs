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
        public AddCliente() {
            InitializeComponent();

            ClienteController clientesController = new ClienteController();
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

            /*try {

                Cliente cli = (Cliente)lvDataBinding.SelectedItem;
                ClienteController clientesController = new ClienteController();

                cli.Nome = txtNome.Text;
                cli.Cpf = txtCpf.Text;
                cli.Endereco = txtEndereco.Text;

                clientesController.Atualizar(cli);
            } catch (Exception ex) {
                MessageBox.Show("Erro ao alterar o cliente (" + ex.Message + ")");
            }*/

            UpdateCliente updateCliente = new UpdateCliente();
            updateCliente.Show();
        }


        private void BtnListClient_Click(object sender, RoutedEventArgs e) {
            Cliente cli = new Cliente();


            ClienteController clientesController = new ClienteController();
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
                ClienteController clientesController = new ClienteController();
                clientesController.Excluir(cli.ClienteID);
            } catch (Exception ex) {
                MessageBox.Show("Selecione um Cliente");
            }

            AddCliente addCliente = new AddCliente();
            addCliente.Show();
            this.Close();
        }
    }
}
