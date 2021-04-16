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
        public SpelRegelsViewModel()
        {
            BackHomeCommand = new BaseCommand(TerugHome);
            dialogService = new DialogService();
        }
        public ICommand BackHomeCommand { get; set; }

        public void TerugHome()
        {
            dialogService.ShowHome();
        }
    }
}
