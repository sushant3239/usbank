using Newtonsoft.Json;
using System;
using Windows.Storage;

namespace UsBank.Infrastructure
{
    public class SessionStorageManager : ISessionStorageManager
    {
        
        public void Remove(string key)
        {
            ApplicationData.Current.LocalSettings.Values.Remove(key);
        }

        public void Add(string key, object value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            ApplicationData.Current.LocalSettings.Values[key] = jsonValue;
        }

        public bool ContainsKey(string key)
        {
            return ApplicationData.Current.LocalSettings.Values.ContainsKey(key);
        }


        public T GetValue<T>(string key)
        {
            if (ContainsKey(key))
            {
                return JsonConvert.DeserializeObject<T>(ApplicationData.Current.LocalSettings.Values[key] as string);
            }
            else
            {
                return default(T);
            }
        }
    }
}
