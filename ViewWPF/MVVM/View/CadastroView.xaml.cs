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

namespace MVVM.View {
    /// <summary>
    /// Lógica interna para CadastroView.xaml
    /// </summary>
    public partial class CadastroView : Window {
        public CadastroView() {
            InitializeComponent();

            AtividadeViewModel vm = new AtividadeViewModel();
            vm.Titulo = "Titulo teste";
            vm.Descricao = "Descrição teste";
            vm.Ativo = true;


            DataContext = new ViewModels.AtividadeViewModel();
        }

        private void BtnSalvar(object sender, RoutedEventArgs e) {
            CadastroView = cv = DataContext as CadastroView;
        }
    }
}
