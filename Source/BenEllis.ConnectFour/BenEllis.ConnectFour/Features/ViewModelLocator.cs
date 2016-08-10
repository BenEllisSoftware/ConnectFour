using BenEllis.ConnectFour.Features.Game;
using BenEllis.ConnectFour.Features.Menu;

namespace BenEllis.ConnectFour.Features
{
    public class ViewModelLocator
    {
         public MenuPageViewModel Menu { get; }

        public GamePageViewModel Game { get; }

        public ViewModelLocator()
        {
            Menu = new MenuPageViewModel();
            Game = new GamePageViewModel();
        }
    }
}