using ProjectMEJN.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMEJN.ViewModel
{
    class HomeScreenViewModel
    {
        private DialogService dialogService;
        public HomeScreenViewModel()
        {
            KoppelenCommands();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();
        }
        private void KoppelenCommands()
        {
            OpenSpelers = new BaseCommand(Openspeler);
            OpenSpellen = new BaseCommand(Openspel);
            OpenSpelregels = new BaseCommand(Openspelregel);
        }
        public ICommand OpenSpelers { get; set; }
        public ICommand OpenSpellen { get; set; }
        public ICommand OpenSpelregels { get; set; }

        private void Openspeler()
        {
            dialogService.ShowSpelers();
            
        }
        private void Openspel()
        {
            dialogService.ShowSpel();

        }
        private void Openspelregel()
        {
            dialogService.ShowSpelregels();

        }
    }
}
