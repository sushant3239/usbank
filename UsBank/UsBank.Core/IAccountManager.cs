using System;
using UsBank.Model;

namespace UsBank.Core
{
    public interface IAccountManager
    {
        User CurrentUser { get; }
        void Setuser(User user);
    }
}
