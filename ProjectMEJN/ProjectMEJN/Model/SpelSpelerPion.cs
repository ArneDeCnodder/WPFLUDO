using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMEJN.Model
{
    public class SpelSpelerPion : BaseModel
    {
        private int id;
        private int spelerid;
        private int spelid;
        private int positie;
        private string kleur;
        private bool isbinnen;

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public int SpelId
        {
            get
            {
                return spelid;
            }

            set
            {
                spelid = value;
                NotifyPropertyChanged();
            }
        }
        public int Positie
        {
            get
            {
                return positie;
            }

            set
            {
                positie = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsBinnen
        {
            get
            {
                return isbinnen;
            }

            set
            {
                isbinnen = value;
                NotifyPropertyChanged();
            }
        }
        public int SpelerId
        {
            get
            {
                return spelerid;
            }

            set
            {
                spelerid = value;
                NotifyPropertyChanged();
            }
        }
        public string Kleur
        {
            get
            {
                return kleur;
            }

            set
            {
                kleur = value;
                NotifyPropertyChanged();
            }
        }

    }
}
