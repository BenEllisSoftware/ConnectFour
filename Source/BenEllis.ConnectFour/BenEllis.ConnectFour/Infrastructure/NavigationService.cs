using System;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BenEllis.ConnectFour.Infrastructure
{
    public class NavigationService
    {
        private static readonly Lazy<NavigationService> Instance = new Lazy<NavigationService>(() => new NavigationService(Window.Current.Content as Frame));

        public static NavigationService Get()
        {
            return Instance.Value;
        }


        private readonly Frame _frame;

        private NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<TPageOrViewModel>()
        {
            NavigateTo<TPageOrViewModel>(null);
        }

        public void NavigateBack()
        {
            if(_frame.CanGoBack)
                _frame.GoBack();
        }

        public void NavigateTo<TPageOrViewModel>(object parameter)
        {
            Type type = GetViewForType<TPageOrViewModel>();
            _frame.Navigate(type, parameter);
        }

        private static Type GetViewForType<TPageOrViewModel>()
        {
            Type type = typeof (TPageOrViewModel);

            string name = type.Name;

            if (name.EndsWith("PageViewModel"))
            {
                string pageName = type.FullName.Substring(0, type.FullName.Length - "ViewModel".Length);
                Type pageType = Type.GetType(pageName, false);
                if (pageType != null)
                    type = pageType;
            }

            if (typeof(Page).IsAssignableFrom(type))
                return type;
            throw new ArgumentException($"Could not find page for type {typeof(TPageOrViewModel).FullName}");
        }
    }
}