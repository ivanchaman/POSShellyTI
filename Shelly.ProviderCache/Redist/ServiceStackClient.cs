using Shelly.ProviderCache.Model;
using ServiceStack.Redis;

namespace Shelly.ProviderCache.Redist
{
     internal class ServiceStackClient : IRedisClient
     {
          private readonly RedisClientConfigurations _RedisEndpoint;
          private TimeSpan _TimeOut;

          public ServiceStackClient(string host, int port, int timeInMinute)
          {
               _TimeOut = TimeSpan.FromMinutes(timeInMinute);
               _RedisEndpoint = new RedisClientConfigurations() { Url = host, Port = port };
          }

          public bool Exists(string key)
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    if (redisClient.ContainsKey(key))
                    {
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }
          public bool Remove(string key)
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    if (redisClient.ContainsKey(key))
                         redisClient.Remove(key);
                    return true;
               }
          }
          public bool Add(string key, string value)
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    redisClient.Set(key, value);
                    return true;
               }
          }
          public bool Add<T>(string key, T value) where T : class
          {
               try
               {
                    using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
                    {
                         redisClient.Set<T>(key, value, _TimeOut);
                    }
                    return true;
               }
               catch (Exception)
               {
                    throw;
               }
          }
         
          public T? Get<T>(string key) where T : class
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    var value = redisClient.Get<T>(key);
                    redisClient.Set<T>(key, value, _TimeOut);
                    return value;
               }
          }         

          public string Get(string key)
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    return redisClient.GetValue(key);
               }
          }

          public bool Update(string key)
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    if (redisClient.ContainsKey(key))
                    {
                         string value = redisClient.GetValue(key);
                         redisClient.Set(key, value, _TimeOut);
                         return true;
                    }
                    return false;
               }
          }
          public bool Update<T>(string key) where T : class
          {
               using (var redisClient = new RedisClient(_RedisEndpoint.Url, _RedisEndpoint.Port))
               {
                    if (redisClient.ContainsKey(key))
                    {
                         var value = redisClient.Get<T>(key);
                         redisClient.Set<T>(key, value, _TimeOut);
                         return true;
                    }
                    return false;
               }
          }


     }
}
