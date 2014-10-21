using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UsBank.Infrastructure
{
    public class BackNavigationHelper
    {
        public ICommand GoBackCommand { get; private set; }

        public BackNavigationHelper()
        {
            GoBackCommand = new DelegateCommand(() => 
            {
                var rootFrame = Window.Current.Content as Frame;
                if (rootFrame != null && rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                }
            });
        }
    }
}
