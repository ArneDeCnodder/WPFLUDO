﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectMEJN.Model;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectMEJN.Extensions;

namespace ProjectMEJN.ViewModel
{
    class SpelViewModel: BaseViewModel
    {
        private DialogService dialogService;
        public SpelViewModel()
        {
            GeefSpellen();
            KoppelenCommands();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();
        }
        private ObservableCollection<Spel> spellen;
        public ObservableCollection<Spel> Spellen
        {
            get
            {
                return spellen;
            }

            set
            {
                spellen = value;
                NotifyPropertyChanged();
            }
        }

        private Spel huidigSpel;
        public Spel HuidigSpel
        {
            get
            {
                if (huidigSpel == null)
                {
                    huidigSpel = new Spel();
                }
                return huidigSpel;
            }

            set
            {
                huidigSpel = value;
                NotifyPropertyChanged();
            }
        }
        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenSpel);
            VerwijderenCommand = new BaseCommand(DeleteSpel);
            ToevoegenCommand = new BaseCommand(AddSpel);
            VoegToeSpelers = new BaseCommand(OpenSpelSpelers);
        }
        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand VoegToeSpelers { get; set; }

        private void GeefSpellen()
        {
            //instantiëren dataservice
            SpelDataService spelDS =
               new SpelDataService();

            Spellen = new ObservableCollection<Spel>(spelDS.GetSpellen());
        }
        public void WijzigenSpel()
        {
            if (HuidigSpel != null)
            {
                SpelDataService spelDS = new SpelDataService();
                spelDS.UpdateSpel(HuidigSpel);

                //Refresh
                GeefSpellen();
            }
        }



        public void AddSpel()
        {
            SpelDataService spelDS = new SpelDataService();
            spelDS.AddSpel(HuidigSpel);

            //Refresh
            GeefSpellen();
        }


        public void DeleteSpel()
        {
            if (HuidigSpel != null)
            {
                SpelDataService spelDS = new SpelDataService();
                spelDS.DeleteSpel(HuidigSpel);

                //Refresh
                GeefSpellen();
            }
        }
        private void OpenSpelSpelers()
        {
            if (HuidigSpel != null)
            {
                Messenger.Default.Send<Spel>(HuidigSpel);

                dialogService.ShowDetailDialog();
            }
        }
    }
}
