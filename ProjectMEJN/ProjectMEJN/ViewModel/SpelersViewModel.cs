﻿using ProjectMEJN.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMEJN.ViewModel
{
    public class SpelersViewModel: BaseViewModel
    {
        public SpelersViewModel()
        {
            GeefSpelers();
            KoppelenCommands();
        }

        private ObservableCollection<Speler> spelers;
        public ObservableCollection<Speler> Spelers
        {
            get
            {
                return spelers;
            }

            set
            {
                spelers = value;
                NotifyPropertyChanged();
            }
        }

        private Speler huidigeSpeler;
        public Speler HuidigeSpeler
        {
            get
            {
                if (huidigeSpeler == null)
                {
                    huidigeSpeler = new Speler();
                }
                return huidigeSpeler;
            }

            set
            {
                huidigeSpeler = value;
                NotifyPropertyChanged();
            }
        }
        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenSpeler);
            VerwijderenCommand = new BaseCommand(DeleteSpeler);
            ToevoegenCommand = new BaseCommand(AddSpeler);
        }
        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        private void GeefSpelers()
        {
            //instantiëren dataservice
            SpelerDataService spelerDS =
               new SpelerDataService();

            Spelers = new ObservableCollection<Speler>(spelerDS.GetSpelers());
        }
        public void WijzigenSpeler()
        {
            if (HuidigeSpeler != null)
            {
                SpelerDataService spelerDS = new SpelerDataService();
                spelerDS.UpdateSpeler(HuidigeSpeler);

                //Refresh
                GeefSpelers();
            }
        }



        public void AddSpeler()
        {
            SpelerDataService spelerDS = new SpelerDataService();
            spelerDS.AddSpeler(HuidigeSpeler);

            //Refresh
            GeefSpelers();
        }


        public void DeleteSpeler()
        {
            if (HuidigeSpeler != null)
            {
                SpelerDataService spelerDS = new SpelerDataService();
                spelerDS.DeleteSpeler(HuidigeSpeler);

                //Refresh
                GeefSpelers();
            }
        }
    }
}
