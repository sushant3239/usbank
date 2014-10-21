using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Windows.Input;
using UsBank.Core;
using UsBank.Infrastructure;
using UsBank.Model;

namespace UsBank.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _userId = String.Empty;
        private string _userPassword = String.Empty;
        private IAccountManager _accountManager;

        private INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService, IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _accountManager = accountManager;

            LoginCommand = new DelegateCommand(Login, CanLogin);
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                if (_userId == value)
                {
                    return;
                }
                _userId = value;
                OnPropertyChanged(() => UserId);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (_userPassword == value)
                {
                    return;
                }
                _userPassword = value;
                OnPropertyChanged(() => UserPassword);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand LoginCommand { get; private set; }

        private void Login()
        {
            _accountManager.Setuser(new User { UserId = UserId, UserPassword = UserPassword });
            _navigationService.NavigateToMainPage();
        }

        private bool CanLogin()
        {
            return !String.IsNullOrEmpty(UserId) && !String.IsNullOrEmpty(UserPassword);
        }
    }
}
