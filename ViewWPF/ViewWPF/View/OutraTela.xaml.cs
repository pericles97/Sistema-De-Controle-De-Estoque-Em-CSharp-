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

namespace ViewWPF.View
{
    /// <summary>
    /// Lógica interna para OutraTela.xaml
    /// </summary>
    public partial class OutraTela : Window
    {
        public OutraTela()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
        }
    }
}
