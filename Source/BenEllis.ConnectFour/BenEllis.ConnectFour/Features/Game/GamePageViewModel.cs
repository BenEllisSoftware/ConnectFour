using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BenEllis.ConnectFour.Features.Game
{
    public class GamePageViewModel : ViewModelBase
    {
        public RelayCommand<GameMode> StartNewGameCommand { get; }

        public GamePageViewModel()
        {
            StartNewGameCommand = new RelayCommand<GameMode>(StartNewGame);
        }

        private void StartNewGame(GameMode mode)
        {
            Debug.WriteLine($"We are starting a game in {mode} mode");
        }
    }
}