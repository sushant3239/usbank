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
        private string _userName = String.Empty;
        private string _userPassword = String.Empty;
        private IAccountManager _accountManager;

        private INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService, IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _accountManager = accountManager;

            LoginCommand = new DelegateCommand(Login, CanLogin);
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value)
                {
                    return;
                }
                _userName = value;
                OnPropertyChanged(() => UserName);
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

        private bool _isMockup = false;
            public bool IsMockup 
            {
                get
                {
                    return _isMockup;
                }
                set
                {
                    _isMockup = value;
                    OnPropertyChanged(() => IsMockup);
                }
            }

        public DelegateCommand LoginCommand { get; private set; }

        private void Login()
        {
            _accountManager.Setuser(new User { UserId = UserName, UserPassword = UserPassword ,IsMockup = IsMockup});
            _navigationService.NavigateToMainPage();
        }

        private bool CanLogin()
        {
            return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(UserPassword);
        }
    }
}
