namespace Shelly.Abstractions.Interfaces
{
     public interface ICacheContext
     {
          bool AuthExistsKey(string key);
          void AuthRemoveKey(string key);
          void AuthSetStrings(string key, string value);
          string AuthGetStrings(string key);
          bool AuthStoreData<T>(string key, T value) where T : class;
          T AuthGetData<T>(string key) where T : class;
          T AuthGetData<T>(string key, out bool isContainsKey) where T : class;

          public bool TwoFactorsExistsKey(string key);
          public void TwoFactorsRemoveKey(string key);
          public void TwoFactorsSetStrings(string key, string value);
          public string TwoFactorsGetStrings(string key);
          public bool TwoFactorsStoreData<T>(string key, T value) where T : class;
          public T TwoFactorsGetData<T>(string key) where T : class;
          public T TwoFactorsGetData<T>(string key, out bool isContainsKey) where T : class;

          bool ActiveExistsKey(string key);
          void ActiveRemoveKey(string key);
          void ActiveSetStrings(string key, string value);
          string ActiveGetStrings(string key);
          bool ActiveStoreData<T>(string key, T value) where T : class;
          T ActiveGetData<T>(string key) where T : class;
          T ActiveGetData<T>(string key, out bool isContainsKey) where T : class;
     }
}
