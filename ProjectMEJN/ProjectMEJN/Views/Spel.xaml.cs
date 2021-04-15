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

namespace ProjectMEJN.Views
{
    /// <summary>
    /// Interaction logic for Spel.xaml
    /// </summary>
    public partial class Spel : Window
    {
        public Spel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window spelspeler = new SpelSpelerPion();
            spelspeler.Show();
            this.Close();
        }
    }
}
