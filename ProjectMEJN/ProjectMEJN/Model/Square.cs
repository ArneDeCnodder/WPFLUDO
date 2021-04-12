using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectMEJN.Model
{
    public class Square : BaseModel
    {
        private int id;
        private int row;
        private int column;
        private SolidColorBrush fillColor;
        private List<int> playersOnSquare;

        public Square(int id, int row, int column, SolidColorBrush fillColor)
        {
            Id = id;
            Row = row;
            Column = column;
            FillColor = fillColor;
            playersOnSquare = new List<int>();
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int Row
        {
            get { return row; }
            set
            {
                row = value;
                NotifyPropertyChanged();
            }
        }

        public int Column
        {
            get { return column; }
            set
            {
                column = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                NotifyPropertyChanged();
            }
        }

        public string Content
        {
            get
            {
                string content = Id + Environment.NewLine;
                if (PlayersOnSquare.Count != 0)
                {
                    content += "P: ";
                    foreach (var player in PlayersOnSquare)
                    {
                        content += player + " ";
                    }
                }

                return content;
            }
        }

        public List<int> PlayersOnSquare
        {
            get { return playersOnSquare; }
            set
            {
                playersOnSquare = value;
                NotifyPropertyChanged("Content");
            }
        }

    }
}
