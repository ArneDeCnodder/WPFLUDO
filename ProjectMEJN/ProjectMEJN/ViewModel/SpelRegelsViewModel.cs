using ProjectMEJN.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMEJN.ViewModel
{
    class SpelRegelsViewModel
    {
        private DialogService dialogService;

        //constructor
        public SpelRegelsViewModel()
        {
            BackHomeCommand = new BaseCommand(TerugHome);
            dialogService = new DialogService();
        }
        public ICommand BackHomeCommand { get; set; }

        //open de view HomeScreen.xaml en sluit huidige view
        public void TerugHome()
        {
            dialogService.ShowHome();
        }
    }
}
