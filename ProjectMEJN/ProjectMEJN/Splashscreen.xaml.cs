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
using System.Windows.Threading;

namespace ProjectMEJN
{
    /// <summary>
    /// Interaction logic for Splashscreen.xaml
    /// </summary>
    public partial class Splashscreen : Window
    {
        //nieuw object maken van dispatchertimer
        DispatcherTimer timer = new DispatcherTimer();
        public Splashscreen()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_Tick);

            //zet de interval voor het tonen van de splashscreen op 10 seconden
            timer.Interval = new TimeSpan(0, 0, 7);
            timer.Start();
        }

        //wat moet er geopend worden na de splashscreen
        private void timer_Tick(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();

            timer.Stop();
            this.Close();
        }
    }
}
