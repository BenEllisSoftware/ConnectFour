using GalaSoft.MvvmLight;

namespace BenEllis.ConnectFour.Features.Game
{
    public class GameBoard
    {
        public int Columns { get; }

        public int Rows { get; }

        public GameBoard(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }

    public class Slot : ObservableObject
    {
        public int Column { get; }

        public int Row { get; }

        private Player _player;
        public Player Player
        {
            get { return _player; }
            set { Set(ref _player, value); }
        }
    }

    public enum Player
    {
        None,
        Player1,
        Player2
    }
}