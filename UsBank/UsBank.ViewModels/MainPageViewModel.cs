using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Input;
using UsBank.Core;
using UsBank.Infrastructure;

namespace UsBank.ViewModels
{
    public class MainPageViewModel
    {
        private INavigationService _navigationService;
        private IAccountManager _accountManager;

        public ICommand NavigateToCustomersCommand { get; set; }

        public string UserName
        {
            get
            {
                var user = _accountManager.CurrentUser;
                return user != null ? user.UserId : String.Empty;
            }
        }
        public MainPageViewModel(INavigationService navigationService,IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _accountManager = accountManager;
            NavigateToCustomersCommand = new DelegateCommand(NaivageToCustomers);
        }

        private void NaivageToCustomers()
        {
            _navigationService.NavigateToCutomersPage();
        }
    }
}
