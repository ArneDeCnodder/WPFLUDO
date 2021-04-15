using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectMEJN.Views;

namespace ProjectMEJN.Extensions
{
    class DialogService
    {

        Window spelspelerstoevoegen = null;

        public DialogService() { }

        public void ShowDetailDialog()
        {
            spelspelerstoevoegen = new SpelSpelerPion();
            spelspelerstoevoegen.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (spelspelerstoevoegen != null)
                spelspelerstoevoegen.Close();
        }
    }
}
