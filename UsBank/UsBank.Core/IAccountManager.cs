using System;
using UsBank.Model;

namespace UsBank.Core
{
    public interface IAccountManager
    {
        User User { get; }
        void Setuser(User user);
    }
}
