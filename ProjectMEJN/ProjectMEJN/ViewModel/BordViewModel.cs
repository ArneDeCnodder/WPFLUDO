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

       
        private Dobbelsteen dobbelsteen;
        public Dobbelsteen Dobbelsteen
        {
            get
            {
                return dobbelsteen;
            }
            set
            {
                dobbelsteen = value;
                NotifyPropertyChanged();
            }
        }

        //constructor
        public BordViewModel()
        {
            Board = new Board();
            KoppelenCommands();
            LeesGegevens();
        }
        public ICommand MovePlayer1Command { get; set; }
        public ICommand MovePlayer2Command { get; set; }
        public ICommand MovePlayer3Command { get; set; }
        public ICommand MovePlayer4Command { get; set; }
        public ICommand StartSpelCommand { get; set; }
       
        private void LeesGegevens()
        {
            Dobbelsteen = new Dobbelsteen();
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
            Dobbelsteen.Gooi();
            int ogen = Dobbelsteen.Ogen;
            string kleur = "Groen";
            Board.MovePlayer(kleur,1, ogen);
        }

        private void MovePlayer2()
        {
            Dobbelsteen.Gooi();
            int ogen = Dobbelsteen.Ogen;
            string kleur = "Blauw";
            Board.MovePlayer(kleur,2, ogen);
        }
        private void MovePlayer3()
        {
            Dobbelsteen.Gooi();
            int ogen = Dobbelsteen.Ogen;
            string kleur = "Geel";
            Board.MovePlayer(kleur,3, ogen);
        }
        private void MovePlayer4()
        {
            Dobbelsteen.Gooi();
            int ogen = Dobbelsteen.Ogen;
            string kleur = "Rood";
            Board.MovePlayer(kleur,4, ogen);
        }

        //zet de spelers op de juiste plaats op het bord
        private void StartSpel()
        {
           Board.PutPlayersOnStart();
        }
    }
}
