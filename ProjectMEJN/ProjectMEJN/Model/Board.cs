using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectMEJN.Model
{
    public class Board : ObservableCollection<Square>
    {

        public Board()
        {
            CreateBoard();
            PutPlayersOnStart();
        }

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
            this.Add(new Square(57, 2, 2, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(58, 2, 3, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(59, 3, 2, new SolidColorBrush(Colors.Gray)));
            this.Add(new Square(60, 3, 3, new SolidColorBrush(Colors.Gray)));

        }

        public void PutPlayersOnStart()
        {
            var startSquare1 = this.FirstOrDefault(s => s.Id == 57);
            var startSquare2 = this.FirstOrDefault(s => s.Id == 58);
            var startSquare3 = this.FirstOrDefault(s => s.Id == 59);
            var startSquare4 = this.FirstOrDefault(s => s.Id == 60);
            startSquare1.PlayersOnSquare = new List<int>() { 1 };
            startSquare2.PlayersOnSquare = new List<int>() { 2 };
            startSquare3.PlayersOnSquare = new List<int>() { 3 };
            startSquare4.PlayersOnSquare = new List<int>() { 4 };
        }

        public void MovePlayer(int playerId, int steps)
        {
            // get current square
            var square = this.FirstOrDefault(s => s.PlayersOnSquare.Contains(playerId));
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
                        //put player 1 on place
                        if (playerId == 1)
                        {
                            var startSquare = this.FirstOrDefault(s => s.Id == 1);
                            if (startSquare != null)
                            {
                                startSquare.PlayersOnSquare.Add(playerId);
                                startSquare.NotifyPropertyChanged("Content");
                            }
                        }
                        //put player 2 on place
                        if (playerId == 2)
                        {
                            var startSquare = this.FirstOrDefault(s => s.Id == 15);
                            if (startSquare != null)
                            {
                                startSquare.PlayersOnSquare.Add(playerId);
                                startSquare.NotifyPropertyChanged("Content");
                            }
                        }
                        //put player 3 on place
                        if (playerId == 3)
                        {
                            var startSquare = this.FirstOrDefault(s => s.Id == 29);
                            if (startSquare != null)
                            {
                                startSquare.PlayersOnSquare.Add(playerId);
                                startSquare.NotifyPropertyChanged("Content");
                            }
                        }
                        //put player 4 on place
                        if (playerId == 4)
                        {
                            var startSquare = this.FirstOrDefault(s => s.Id == 43);
                            if (startSquare != null)
                            {
                                startSquare.PlayersOnSquare.Add(playerId);
                                startSquare.NotifyPropertyChanged("Content");
                            }
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
                        }
                    }
                }
            }
        }
        public void PutOnStart1(int playerId)
        {
            var square = this.FirstOrDefault(s => s.PlayersOnSquare.Contains(playerId));
            if (square != null)
            {

            }
        }
    }
}
