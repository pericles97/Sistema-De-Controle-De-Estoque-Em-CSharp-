﻿using Controllers.Controllers;
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

                ClienteController clientesController = new ClienteController();
                clientesController.Adicionar(cli);

                MessageBox.Show("Cliente salvo com sucesso!");
            } catch (Exception ex) {
                MessageBox.Show("Erro ao salvar o cliente (" + ex.Message + ")");
            }


            this.Close();
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
            this.Close();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {
            Cliente cli = (Cliente) lvDataBinding.SelectedItem;
            ClienteController clientesController = new ClienteController();
            clientesController.Excluir(cli.ClienteID);
        }
    }
}
