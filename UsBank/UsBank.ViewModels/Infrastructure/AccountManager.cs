using System;
using UsBank.Core;
using UsBank.Infrastructure;
using UsBank.Model;

namespace UsBank.ViewModels.Infrastructure
{
    public class AccountManager : IAccountManager
    {
        private ISessionStorageManager _storageManager;

        public AccountManager(ISessionStorageManager storageManager)
        {
            _storageManager = storageManager;
        }

        public User CurrentUser
        {
            get 
            {
                return GetUserFromSession();
            }
        }
        
        private User GetUserFromSession()
        {
            var user = _storageManager.GetValue<User>(Constants.UserKey);
            return user ?? null;
        }
        public void Setuser(User user)
        {
            _storageManager.Add<User>(Constants.UserKey, user);
        }
    }
}
