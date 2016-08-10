using BenEllis.ConnectFour.Features.Game;
using BenEllis.ConnectFour.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BenEllis.ConnectFour.Features.Menu
{
    public class MenuPageViewModel : ViewModelBase
    {
        public RelayCommand StartOnePlayerGameCommand { get; }

        public RelayCommand StartTwoPlayerGameCommand { get; }

        public MenuPageViewModel()
        {
            StartOnePlayerGameCommand = new RelayCommand(StartOnePlayerGame);
            StartTwoPlayerGameCommand = new RelayCommand(StartTwoPlayerGame);
        }

        private void StartOnePlayerGame()
        {
            NavigationService.Get().NavigateTo<GamePageViewModel>(GameMode.OnePlayer);
        }

        private void StartTwoPlayerGame()
        {
            NavigationService.Get().NavigateTo<GamePageViewModel>(GameMode.TwoPlayer);
        }
    }
}