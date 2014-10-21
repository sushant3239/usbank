using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UsBank.Infrastructure
{
    public class NavigationService : INavigationService
    {
        private Frame rootFrame;
        public NavigationService()
        {
            rootFrame = Window.Current.Content as Frame;
        }

        public void NavigateToCutomersPage()
        {
            rootFrame.Navigate(typeof(Customers));
        }


        public void NavigateToMainPage()
        {
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
