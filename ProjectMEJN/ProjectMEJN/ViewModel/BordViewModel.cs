using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectMEJN.Model;


namespace ProjectMEJN.ViewModel
{
    public class BordViewModel : BaseViewModel
    {
        private Board board;
        public Board Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand MovePlayer1Command { get; set; }
        public ICommand MovePlayer2Command { get; set; }
        public ICommand MovePlayer3Command { get; set; }
        public ICommand MovePlayer4Command { get; set; }
        public ICommand StartSpelCommand { get; set; }

        public BordViewModel()
        {
            Board = new Board();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            MovePlayer1Command = new BaseCommand(MovePlayer1);
            MovePlayer2Command = new BaseCommand(MovePlayer2);
            MovePlayer3Command = new BaseCommand(MovePlayer3);
            MovePlayer4Command = new BaseCommand(MovePlayer4);
            StartSpelCommand = new BaseCommand(StartSpel);
        }

        private void MovePlayer1()
        {
            // better use the dice model
            Random random = new Random();
            string kleur = "groen";
            Board.MovePlayer(1, random.Next(1, 7));
        }

        private void StartSpel()
        {
            
        }

        private void MovePlayer2()
        {
            Random random = new Random();
            string kleur = "blauw";
            Board.MovePlayer(2, random.Next(1, 7));
        }
        private void MovePlayer3()
        {
            Random random = new Random();
            string kleur = "geel";
            Board.MovePlayer(3, random.Next(1, 7));
        }
        private void MovePlayer4()
        {
            Random random = new Random();
            string kleur = "rood";
            Board.MovePlayer(4, random.Next(1, 7));
        }
    }
}
