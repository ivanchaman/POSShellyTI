using Shelly.Abstractions.Interfaces;
using Shelly.ProviderCache.Constants;
using Shelly.Abstractions.Settings.Options;
using Shelly.ProviderCache.Redist;
using Microsoft.Extensions.Caching.Memory;
using Shelly.ProviderCache.MemoryCache;

namespace Shelly.ProviderCache
{
    public class CacheContext : ICacheContext
     {
          private IRedisClient _Auth;
          private IRedisClient _Active;
          //private IRedisClient _Recovery;
          //private IRedisClient _Register;
          private IRedisClient _TwoFactors;
          private Cache _cacheOptions;
          public CacheContext(Cache cacheOptions, IMemoryCache memoryCache)
          {
               _cacheOptions = cacheOptions;
               switch(_cacheOptions.Type)
               {
                    case "-1":
                         _Auth = new MemoryCacheClient(memoryCache, Convert.ToInt32(_cacheOptions.TimeoutAuth));
                         _Active = new MemoryCacheClient(memoryCache, Convert.ToInt32(_cacheOptions.TimeoutActive));
                         _TwoFactors = new MemoryCacheClient(memoryCache, Convert.ToInt32(_cacheOptions.TimeoutTwoFactors));
                         break;
                    case "0":
                         _Auth = new ServiceStackClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutAuth));
                         _Active = new ServiceStackClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutActive));
                         //_Recovery = new ServiceStackClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutRecovery));
                         //_Register = new ServiceStackClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutRegister));
                         _TwoFactors = new ServiceStackClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutTwoFactors));
                         break;
                    case "1":
                         _Auth = new StackExchangeRedisClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutAuth));
                         _Active = new StackExchangeRedisClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutActive));
                         //_Recovery = new StackExchangeRedisClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutRecovery));
                         //_Register = new StackExchangeRedisClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutRegister));
                         _TwoFactors = new StackExchangeRedisClient(_cacheOptions.Host, Convert.ToInt32(_cacheOptions.Port), Convert.ToInt32(_cacheOptions.TimeoutTwoFactors));
                         break;
               }
               
          }
         
          #region Auth
          public bool AuthExistsKey(string key)
          {
               return _Auth.Exists($"{Authentication.LOGGED}{key}");
          }

          public void AuthRemoveKey(string key)
          {
               _Auth.Remove ($"{Authentication.LOGGED}{key}");
          }

          public void AuthSetStrings(string key, string value)
          {
               _Auth.Add($"{Authentication.LOGGED}{key}", value);
          }

          public string AuthGetStrings(string key)
          {
               return _Auth.Get($"{Authentication.LOGGED}{key}");
          }

          public bool AuthStoreData<T>(string key, T value) where T : class
          {
               return _Auth.Add<T>($"{Authentication.LOGGED}{key}", value);
          }

          public T AuthGetData<T>(string key) where T : class
          {
               return _Auth.Get<T>($"{Authentication.LOGGED}{key}");
          }

          public T AuthGetData<T>(string key, out bool isContainsKey) where T : class
          {
               isContainsKey = false;
               return _Auth.Get<T>($"{Authentication.LOGGED}{key}");
          }
          #endregion
          #region TwoFactors
         
          public bool TwoFactorsExistsKey(string key)
          {
               var result = _TwoFactors.Exists($"{Authentication.LOGGETWOFACTOR}{key}");
               return result;
          }

          public void TwoFactorsRemoveKey(string key)
          {
              var resutul = _TwoFactors.Remove($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public void TwoFactorsSetStrings(string key, string value)
          {
               _TwoFactors.Add($"{Authentication.LOGGETWOFACTOR}{key}", value);
          }

          public string TwoFactorsGetStrings(string key)
          {
               return _TwoFactors.Get($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public bool TwoFactorsStoreData<T>(string key, T value) where T : class
          {
               bool result = _TwoFactors.Add($"{Authentication.LOGGETWOFACTOR}{key}", value);
               return result;
          }

          public T TwoFactorsGetData<T>(string key) where T : class
          {
               return _TwoFactors.Get<T>($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public T TwoFactorsGetData<T>(string key, out bool isContainsKey) where T : class
          {
               isContainsKey = false;
               return _TwoFactors.Get<T>($"{Authentication.LOGGETWOFACTOR}{key}");
          }
          #endregion

          #region Active

          public bool ActiveExistsKey(string key)
          {
               var result = _Active.Exists($"{Authentication.LOGGETWOFACTOR}{key}");
               return result;
          }

          public void ActiveRemoveKey(string key)
          {
               var resutul = _Active.Remove($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public void ActiveSetStrings(string key, string value)
          {
               _Active.Add($"{Authentication.LOGGETWOFACTOR}{key}", value);
          }

          public string ActiveGetStrings(string key)
          {
               return _Active.Get($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public bool ActiveStoreData<T>(string key, T value) where T : class
          {
               bool result = _Active.Add($"{Authentication.LOGGETWOFACTOR}{key}", value);
               return result;
          }

          public T ActiveGetData<T>(string key) where T : class
          {
               return _Active.Get<T>($"{Authentication.LOGGETWOFACTOR}{key}");
          }

          public T ActiveGetData<T>(string key, out bool isContainsKey) where T : class
          {
               isContainsKey = false;
               return _Active.Get<T>($"{Authentication.LOGGETWOFACTOR}{key}");
          }
          #endregion
     }
}
