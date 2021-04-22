using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProjectMEJN.Extensions;

namespace ProjectMEJN.Model
{
    public class Board : ObservableCollection<Square>
    {
        //constructor
        public Board()
        {
            CreateBoard();
            PutPlayersOnStart();
            Messenger.Default.Register<Spel>(this, OnspelReceived);
        }
        // Huidigspel van SpelViewModel
        private Spel huidigSpel;
        public Spel HuidigSpel
        {
            get
            {
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

        //creëer het spelbord

        private void CreateBoard()
        {
            //green
            for (int i = 1; i < 4; i++)
            {
                this.Add(new Square(i, 0, i + 5, new SolidColorBrush(Colors.LightGreen)));
            }
            for (int i = 4; i < 10; i++)
            {
                this.Add(new Square(i, i - 3, 8, new SolidColorBrush(Colors.LightGreen)));
            }
            for (int i = 10; i < 15; i++)
            {
                this.Add(new Square(i, 6, i - 1, new SolidColorBrush(Colors.LightGreen)));
            }

            //yellow
            this.Add(new Square(15, 6, 14, new SolidColorBrush(Colors.Yellow)));
            this.Add(new Square(16, 7, 14, new SolidColorBrush(Colors.Yellow)));
            this.Add(new Square(17, 8, 14, new SolidColorBrush(Colors.Yellow)));

            for (int i = 1; i < 7; i++)
            {
                this.Add(new Square(i + 17, 8, 14 - i, new SolidColorBrush(Colors.Yellow)));
            }
            for (int i = 1; i < 6; i++)
            {
                this.Add(new Square(i + 23, 8 + i, 8, new SolidColorBrush(Colors.Yellow)));
            }

            //blue
            this.Add(new Square(29, 14, 8, new SolidColorBrush(Colors.CornflowerBlue)));
            this.Add(new Square(30, 14, 7, new SolidColorBrush(Colors.CornflowerBlue)));
            this.Add(new Square(31, 14, 6, new SolidColorBrush(Colors.CornflowerBlue)));

            for (int i = 1; i < 7; i++)
            {
                this.Add(new Square(i + 31, 14 - i, 6, new SolidColorBrush(Colors.CornflowerBlue)));
            }
            for (int i = 1; i < 6; i++)
            {
                this.Add(new Square(i + 37, 8, 6 - i, new SolidColorBrush(Colors.CornflowerBlue)));
            }

            //red
            this.Add(new Square(43, 8, 0, new SolidColorBrush(Colors.Red)));
            this.Add(new Square(44, 7, 0, new SolidColorBrush(Colors.Red)));
            this.Add(new Square(45, 6, 0, new SolidColorBrush(Colors.Red)));

            for (int i = 1; i < 7; i++)
            {
                this.Add(new Square(i + 45, 6, i, new SolidColorBrush(Colors.Red)));
            }
            for (int i = 1; i < 6; i++)
            {
                this.Add(new Square(i + 51, 6 - i, 6, new SolidColorBrush(Colors.Red)));
            }
            //start
            this.Add(new Square(57, 3, 3, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(58, 3, 11, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(59, 10, 11, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(60, 10, 3, new SolidColorBrush(Colors.Gray)));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Pionnen van alle spelers vanuit SpelSpelerPionViewModel

        private SpelSpelerPion speler;
        public SpelSpelerPion Speler
        {
            get
            {
                return speler;
            }

            set
            {
                speler = value;
                NotifyPropertyChanged();
            }
        }

        //zet de pionnen op hun positie die overeenkomt met positie in database
        public void PutPlayersOnStart()
        {
            
            if(huidigSpel!=null)
            {
                int spelid = huidigSpel.ID;
                BoardDataService boardgroenDS = new BoardDataService();
                speler = boardgroenDS.GetSpecificspeler("Groen", spelid);
                var startSquare1 = this.FirstOrDefault(s => s.Id == speler.Positie);

                BoardDataService boardblauwDS = new BoardDataService();
                speler = boardblauwDS.GetSpecificspeler("Blauw", spelid);
                var startSquare2 = this.FirstOrDefault(s => s.Id == speler.Positie);

                BoardDataService boardgeelDS = new BoardDataService();
                speler = boardgeelDS.GetSpecificspeler("Geel", spelid);
                var startSquare3 = this.FirstOrDefault(s => s.Id == speler.Positie);

                BoardDataService boardroodDS = new BoardDataService();
                speler = boardroodDS.GetSpecificspeler("Rood", spelid);
                var startSquare4 = this.FirstOrDefault(s => s.Id == speler.Positie);
                startSquare1.PlayersOnSquare = new List<int>() { 1 };
                startSquare2.PlayersOnSquare = new List<int>() { 2 };
                startSquare3.PlayersOnSquare = new List<int>() { 3 };
                startSquare4.PlayersOnSquare = new List<int>() { 4 };
            }
            
        }

        //verplaats de speler
        public void MovePlayer(string kleur, int playerId, int steps)
        {
            // get current square
            var square = this.FirstOrDefault(s => s.PlayersOnSquare.Contains(playerId));

            if (playerId == 1)
            {
                if (square.PlayersOnSquare.Contains(2))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(2);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 58);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(2);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 58);
                    }
                }
                if (square.PlayersOnSquare.Contains(3))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(3);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 59);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(3);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 59);
                    }
                }
                if (square.PlayersOnSquare.Contains(4))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(4);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 60);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(4);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 60);
                    }
                }
            }
            if (playerId == 2)
            {
                if (square.PlayersOnSquare.Contains(1))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(1);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 57);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(1);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 57);
                    }
                }
                if (square.PlayersOnSquare.Contains(3))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(3);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 59);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(3);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 59);
                    }
                }
                if (square.PlayersOnSquare.Contains(4))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(4);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 60);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(4);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 60);
                    }
                }
            }
            if (playerId == 3)
            {
                if (square.PlayersOnSquare.Contains(2))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(2);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 58);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(2);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 58);
                    }
                }
                if (square.PlayersOnSquare.Contains(1))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(1);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 57);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(1);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 57);
                    }
                }
                if (square.PlayersOnSquare.Contains(4))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(4);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 60);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(4);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 60);
                    }
                }
            }
            if (playerId == 4)
            {
                if (square.PlayersOnSquare.Contains(2))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(2);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 58);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(2);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 58);

                    }
                }
                if (square.PlayersOnSquare.Contains(3))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(3);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 59);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(3);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 59);
                    }
                }
                if (square.PlayersOnSquare.Contains(1))
                {
                    // remove player from this square
                    square.PlayersOnSquare.Remove(1);
                    square.NotifyPropertyChanged("Content");
                    var startSquare = this.FirstOrDefault(s => s.Id == 57);
                    if (startSquare != null)
                    {
                        startSquare.PlayersOnSquare.Add(1);
                        startSquare.NotifyPropertyChanged("Content");
                        BoardDataService boardDS = new BoardDataService();
                        boardDS.UpdatePosition(kleur, HuidigSpel.ID, 57);
                    }
                }
            }

            if (square != null)
            {
                int currentSquare = square.Id;
                //check whether first roll is 6 and move to startposition
                if (steps == 6)
                {
                    if (currentSquare == 57 || currentSquare == 58 || currentSquare == 59 || currentSquare == 60)
                    {
                        // remove player from this square
                        square.PlayersOnSquare.Remove(playerId);
                        square.NotifyPropertyChanged("Content");
                        
                        var startSquare = this.FirstOrDefault(s => s.Id == 1);
                        if (startSquare != null)
                        {
                            startSquare.PlayersOnSquare.Add(playerId);
                            startSquare.NotifyPropertyChanged("Content");
                            BoardDataService boardDS = new BoardDataService();
                            boardDS.UpdatePosition(kleur, HuidigSpel.ID, 1);
                        }                   
                    }
                    else
                    //move the player around the board
                    {
                        // remove player from this square
                        square.PlayersOnSquare.Remove(playerId);
                        square.NotifyPropertyChanged("Content");
                        // get next square
                        var newSquare = this.FirstOrDefault(s => s.Id == (currentSquare + steps));
                        if (newSquare != null)
                        {
                            newSquare.PlayersOnSquare.Add(playerId);
                            newSquare.NotifyPropertyChanged("Content");
                            BoardDataService boardDS = new BoardDataService();
                            boardDS.UpdatePosition(kleur, HuidigSpel.ID, currentSquare + steps);
                        }
                    }
                }
                else
                //check whether to move the player on the board if still in start or not
                {
                    if (currentSquare != 57 && currentSquare != 58 && currentSquare != 59 && currentSquare != 60)
                    {
                        // remove player from this square
                        square.PlayersOnSquare.Remove(playerId);
                        square.NotifyPropertyChanged("Content");
                        // get next square
                        var newSquare = this.FirstOrDefault(s => s.Id == (currentSquare + steps));
                        if (newSquare != null)
                        {
                            newSquare.PlayersOnSquare.Add(playerId);
                            newSquare.NotifyPropertyChanged("Content");
                            BoardDataService boardDS = new BoardDataService();
                            boardDS.UpdatePosition(kleur, HuidigSpel.ID, currentSquare + steps);
                        }
                    }
                }
            }
        }
    }
}
