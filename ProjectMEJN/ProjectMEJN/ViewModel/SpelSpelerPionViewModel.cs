﻿using ProjectMEJN.Extensions;
using ProjectMEJN.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMEJN.ViewModel
{
    class SpelSpelerPionViewModel: BaseViewModel
    {
        public SpelSpelerPionViewModel()
        {
            GeefSpelers();
            GeefSpelSpelers();
            KoppelenCommands();
            Messenger.Default.Register<Spel>(this, OnspelReceived);
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
        private void OnspelReceived(Spel spel)
        {
            HuidigSpel = spel;
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

        private ObservableCollection<SpelSpelerPion> spelspelers;
        public ObservableCollection<SpelSpelerPion> SpelSpelers
        {
            get
            {
                return spelspelers;
            }

            set
            {
                spelspelers = value;
                NotifyPropertyChanged();
            }
        }

        private Speler huidigeSpelspeler;
        public Speler HuidigeSpelspeler
        {
            get
            {
                if (huidigeSpelspeler == null)
                {
                    huidigeSpelspeler = new Speler();
                }
                return huidigeSpelspeler;
            }

            set
            {
                huidigeSpelspeler = value;
                NotifyPropertyChanged();
            }
        }
        private void KoppelenCommands()
        {
            Inschrijven1Command = new BaseCommand(InschrijvenSpeler1);
            Inschrijven2Command = new BaseCommand(InschrijvenSpeler2);
            Inschrijven3Command = new BaseCommand(InschrijvenSpeler3);
            Inschrijven4Command = new BaseCommand(InschrijvenSpeler4);
            //UitschrijvenCommand = new BaseCommand(UitschrijvenSpeler);

        }
        public ICommand Inschrijven1Command { get; set; }
        public ICommand Inschrijven2Command { get; set; }
        public ICommand Inschrijven3Command { get; set; }
        public ICommand Inschrijven4Command { get; set; }



        private void GeefSpelers()
        {
            //instantiëren dataservice
            SpelerDataService spelerDS = new SpelerDataService();

            Spelers = new ObservableCollection<Speler>(spelerDS.GetSpelers());
        }
        private void GeefSpelSpelers()
        {
            int spelid = HuidigSpel.ID;
            //instantiëren dataservice
            SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();

            SpelSpelers = new ObservableCollection<SpelSpelerPion>(spelspelerDS.GetSpelSpelers(spelid));
        }

        //private void UitschrijvenSpeler()
        //{
        //    if (HuidigeSpeler != null)
        //    {
        //        SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();
        //        spelspelerDS.VerwijderSpelSpeler(HuidigeSpeler);

        //        Refresh
        //        GeefSpelers();
        //        GeefSpelSpelers();
        //    }
        //}

        private void InschrijvenSpeler1()
        {
            if (HuidigeSpelspeler != null)
            {
                int spelid = HuidigSpel.ID;
                var aantal = spelspelers.Count;
                int id = HuidigeSpelspeler.ID;
                var dezespeler = new SpelSpelerPion();
                SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();
                spelspelerDS.UpdateSpelSpeler(dezespeler,id,aantal,spelid);

                //Refresh
                GeefSpelSpelers();
                GeefSpelers();
             
            }
        }
        private void InschrijvenSpeler2()
        {
            if (HuidigeSpelspeler != null)
            {
                int spelid = HuidigSpel.ID;
                var aantal = spelspelers.Count;
                int id = HuidigeSpelspeler.ID;
                var dezespeler = new SpelSpelerPion();
                SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();
                spelspelerDS.UpdateSpelSpeler(dezespeler, id, aantal, spelid);

                //Refresh
                GeefSpelSpelers();
                GeefSpelers();

            }
        }
        private void InschrijvenSpeler3()
        {
            if (HuidigeSpelspeler != null)
            {
                int spelid = HuidigSpel.ID;
                var aantal = spelspelers.Count;
                int id = HuidigeSpelspeler.ID;
                var dezespeler = new SpelSpelerPion();
                SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();
                spelspelerDS.UpdateSpelSpeler(dezespeler, id, aantal, spelid);

                //Refresh
                GeefSpelSpelers();
                GeefSpelers();

            }
        }
        private void InschrijvenSpeler4()
        {
            if (HuidigeSpelspeler != null)
            {
                int spelid = HuidigSpel.ID;
                var aantal = spelspelers.Count;
                int id = HuidigeSpelspeler.ID;
                var dezespeler = new SpelSpelerPion();
                SpelSpelerPionDataService spelspelerDS = new SpelSpelerPionDataService();
                spelspelerDS.UpdateSpelSpeler(dezespeler, id, aantal, spelid);

                //Refresh
                GeefSpelSpelers();
                GeefSpelers();

            }
        }
    }
}