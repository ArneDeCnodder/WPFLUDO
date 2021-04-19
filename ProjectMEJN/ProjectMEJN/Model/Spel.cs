using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMEJN.Model
{
    public class Spel : BaseModel
    {
        private int id;
        private string naam;
        private string datum;

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

        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                naam = value;
                NotifyPropertyChanged();
            }
        }
        public string Datum
        {
            get
            {
                return datum;
            }

            set
            {
                datum = value;
                NotifyPropertyChanged();
            }
        }
    }
}
