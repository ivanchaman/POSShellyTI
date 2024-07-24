using StackExchange.Redis;

namespace Shelly.ProviderCache
{
     internal interface IRedisClient
     {
          bool Remove(string key);       
          bool Exists(string key);        
          bool Add(string key, string value);
          bool Add<T>(string key, T value) where T : class;
          bool Update(string key);
          bool Update<T>(string key) where T : class;
          T Get<T>(string key) where T : class;
          string Get(string key);

     }
}
