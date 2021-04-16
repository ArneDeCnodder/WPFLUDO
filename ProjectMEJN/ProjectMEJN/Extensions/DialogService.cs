using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectMEJN.Views;

namespace ProjectMEJN.Extensions
{
    public class DialogService
    {

        Window window = null;

        public DialogService() { }

        public void ShowSpelSpelerPion()
        {
            window = new SpelSpelerPion();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
        public void ShowSpelers()
        {
            window = new Spelers();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
        public void ShowSpelregels()
        {
            window = new SpelRegels();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
        public void ShowHome()
        {
            window = new HomeScreen();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
        public void ShowSpel()
        {
            window = new Spel();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
        public void ShowBord()
        {
            window = new Bord();
            Application.Current.Windows[0].Close();
            window.ShowDialog();
        }
    }
}
