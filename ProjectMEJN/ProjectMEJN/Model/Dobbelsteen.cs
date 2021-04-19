using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMEJN.Model
{
    public class Dobbelsteen : BaseModel
    {
        Random random = new Random();

        private int ogen;

        public int Ogen
        {
            get { return ogen; }
        }

        public string Afbeelding
        {
            get
            {
                return "/assets/dice-" + ogen + ".png";
            }
        }

        public void Gooi()
        {
            ogen = random.Next(1, 7);
            NotifyPropertyChanged("Ogen");
            NotifyPropertyChanged("Afbeelding");
        }

        public Dobbelsteen()
        {
            Gooi();
        }

    }
}
