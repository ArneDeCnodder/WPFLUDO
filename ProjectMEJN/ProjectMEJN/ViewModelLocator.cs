using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMEJN.ViewModel;

namespace ProjectMEJN
{
    public class ViewModelLocator
    {
        private static BordViewModel bordViewModel = new BordViewModel();

        public static BordViewModel BordViewModel
        {
            get
            {
                return bordViewModel;
            }
        }
    }
}
