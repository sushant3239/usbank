using System;

namespace UsBank.Infrastructure
{
    public interface ISessionStorageManager
    {
        void Remove(string key);

        void Add<T>(string key, T value);

        T GetValue<T>(string key);

        bool ContainsKey(string key);
    }
}
