using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BenEllis.ConnectFour.Features.Game
{
    public class GamePageViewModel : ViewModelBase
    {
        public RelayCommand<GameMode> StartNewGameCommand { get; }

        private GameBoard _board;
        public GameBoard Board
        {
            get { return _board; }
            private set { Set(ref _board, value); }
        }

        public GamePageViewModel()
        {
            StartNewGameCommand = new RelayCommand<GameMode>(StartNewGame);
        }

        private void StartNewGame(GameMode mode)
        {
            Debug.WriteLine($"We are starting a game in {mode} mode");

            Board = new GameBoard(7, 6);
        }
    }
}