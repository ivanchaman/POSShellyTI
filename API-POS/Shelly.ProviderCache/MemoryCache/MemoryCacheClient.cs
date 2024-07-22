using Shelly.Abstractions.Settings.Options;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Shelly.ProviderCache.MemoryCache
{
     public class MemoryCacheClient : IRedisClient
     {
          readonly IMemoryCache _memoryCache;
          private TimeSpan _TimeOut;
          public MemoryCacheClient(IMemoryCache memoryCache, int timeInMinute) 
          {
               _memoryCache = memoryCache;
               _TimeOut = TimeSpan.FromMinutes(timeInMinute);
          }     
          public bool Add(string key, string value)
          {
               _memoryCache.Set(key, value, _TimeOut);
               return true;

          }

          public bool Add<T>(string key, T value) where T : class
          {
               _memoryCache.Set(key, value, _TimeOut);
               return true;
          }

          public bool Exists(string key)
          {
               try
               {
                    object? data = _memoryCache.Get(key);
                    if (data != null)
                    {
                         _memoryCache.Set(key, data, _TimeOut);
                         return true;
                    }
                    return false;
               }
               catch (Exception)
               {
                    return false;
               }
          }

          public T Get<T>(string key) where T : class
          {
               try
               {
                    T? data = _memoryCache.Get<T>(key);
                    if (data != null)
                    {
                         _memoryCache.Set(key, data, _TimeOut);
                         return data;
                    }
                    return null;
               }
               catch (Exception)
               {
                    return null;
               }
          }

          public string Get(string key)
          {
               try
               {
                    string myString = _memoryCache.Get<string>(key);
                    if (string.IsNullOrEmpty(myString))
                    {
                         _memoryCache.Set(key, myString, _TimeOut);
                         return myString;
                    }
                    return "";
               }
               catch (Exception)
               {
                    return "";
               }
          }

          public bool Remove(string key)
          {
               try
               {
                    _memoryCache.Remove(key);
               }
               catch 
               {                    
               }
               return true;
          }

          public bool Update(string key)
          {
               try
               {
                    object? data = _memoryCache.Get(key);
                    if (data != null)
                    {
                         _memoryCache.Set(key, data, _TimeOut);
                         return true;
                    }
                    return false;
               }
               catch (Exception)
               {
                    return false;
               }
          }

          public bool Update<T>(string key) where T : class
          {
               try
               {
                    T? data = _memoryCache.Get<T>(key);
                    if (data != null)
                    {
                         _memoryCache.Set(key, data, _TimeOut);
                         return true;
                    }
                    return false;
               }
               catch (Exception)
               {
                    return false;
               }
          }

          private string SerializeContent<T>(T value)
          {
               return JsonConvert.SerializeObject(value);
          }
          private T? DeserializeContent<T>(RedisValue myString)
          {
               return JsonConvert.DeserializeObject<T>(myString);
          }
     }
}
