using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMEJN.ViewModel;

namespace ProjectMEJN
{
    class ViewModelLocator
    {
        private static BordViewModel bordViewModel = new BordViewModel();
        private static SpelViewModel spelViewModel = new SpelViewModel();
        private static SpelSpelerPionViewModel spelSpelerPionViewModel = new SpelSpelerPionViewModel();
        private static HomeScreenViewModel homeScreenViewModel = new HomeScreenViewModel();
        private static SpelersViewModel spelersViewModel = new SpelersViewModel();
        private static SpelRegelsViewModel spelregelsViewModel = new SpelRegelsViewModel();

        public static BordViewModel BordViewModel
        {
            get
            {
                return bordViewModel;
            }
        }

        public static SpelViewModel SpelViewModel
        {
            get
            {
                return spelViewModel;
            }
        }

        public static SpelSpelerPionViewModel SpelSpelerPionViewModel
        {
            get
            {
                return spelSpelerPionViewModel;
            }
        }

        public static HomeScreenViewModel HomeScreenViewModel
        {
            get
            {
                return homeScreenViewModel;
            }
        }

        public static SpelersViewModel SpelersViewModel
        {
            get
            {
                return spelersViewModel;
            }
        }

        public static SpelRegelsViewModel SpelregelsViewModel
        {
            get
            {
                return spelregelsViewModel;
            }
        }
    }
}
