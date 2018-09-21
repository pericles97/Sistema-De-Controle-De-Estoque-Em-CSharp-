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
    /// Lógica interna para UpdateCliente.xaml
    /// </summary>
    public partial class UpdateCliente : Window {
        public UpdateCliente() {
            InitializeComponent();

            ClienteController clientesController = new ClienteController();
            clientesController.ListarTodos();

                //lvDataBinding.ItemsSource = clientesController.ListarTodos();
        }

        private void BtnUpdateClient_Click(object sender, RoutedEventArgs e) {
            Cliente cli = new Cliente();
            ClienteController clientesController = new ClienteController();

            cli.Nome = txtNome.Text;
            cli.Cpf = txtCpf.Text;
            cli.Endereco = txtEndereco.Text;

            clientesController.Atualizar(cli);
            //clientesController.Excluir(cli.ClienteID);

            /*BindingExpression nome = txtNome.GetBindingExpression(TextBox.TextProperty);
            nome.UpdateSource();

            BindingExpression cpf = txtNome.GetBindingExpression(TextBox.TextProperty);
            cpf.UpdateSource();

            BindingExpression end = txtNome.GetBindingExpression(TextBox.TextProperty);
            end.UpdateSource();*/

            //txtNome.Text = string.Empty;

        }

        private void BtnCancelClient_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
