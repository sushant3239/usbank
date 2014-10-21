using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;
using UsBank.Infrastructure;

namespace UsBank.ViewModels
{
    public class MainPageViewModel
    {
        private INavigationService _navigationService;
        public ICommand NavigateToCustomersCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToCustomersCommand = new DelegateCommand(NaivageToCustomers);

        }

        private void NaivageToCustomers()
        {
            _navigationService.NavigateToCutomersPage();
        }
    }
}
