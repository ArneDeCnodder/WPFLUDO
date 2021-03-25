using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMEJN.Model
{
    public class Speler : BaseModel
    {
        private int id;
        private string voornaam;
        private string familienaam;
        private string kleur;

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

        public string Voornaam
        {
            get
            {
                return voornaam;
            }

            set
            {
                voornaam = value;
                NotifyPropertyChanged();
            }
        }
        public string Familienaam
        {
            get
            {
                return familienaam;
            }

            set
            {
                familienaam = value;
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
