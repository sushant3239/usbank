using System;

namespace UsBank.Infrastructure
{
    public interface ISessionStorageManager
    {
        void Remove(string key);

        void Add(string key, object value);

        T GetValue<T>(string key);

        bool ContainsKey(string key);
    }
}
