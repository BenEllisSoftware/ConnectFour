using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BenEllis.ConnectFour.Features.Game
{
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // ReSharper disable once PossibleNullReferenceException
            (DataContext as GamePageViewModel)?.StartNewGameCommand.Execute((GameMode)e.Parameter);
        }
    }
}
