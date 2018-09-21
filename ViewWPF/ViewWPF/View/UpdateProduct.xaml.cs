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
        public UpdateProduct() {
            InitializeComponent();
        }

        private void BtnUpdateProduct_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnCancelProduct_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
