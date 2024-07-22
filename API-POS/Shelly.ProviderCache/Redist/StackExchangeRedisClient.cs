using Newtonsoft.Json;
using Shelly.ProviderCache.Model;
using StackExchange.Redis;
namespace Shelly.ProviderCache.Redist
{
     internal class StackExchangeRedisClient: IRedisClient
     {
          private readonly RedisClientConfigurations _RedisEndpoint;                  
          public StackExchangeRedisClient(string host, int port, int timeInMinute)
          {
               _RedisEndpoint = new RedisClientConfigurations() { Url = host, Port = port, ConnectTimeout = TimeSpan.FromMinutes(timeInMinute) };              
          }
         
          public bool Exists(string key)
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               return database.KeyExists(key);
          }
          public bool Remove(string key)
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               if (database.KeyExists(key))
                    database.KeyDelete(key);
               return true;
          }
          public bool Add(string key, string value)
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               var stringContent = SerializeContent(value);
               return database.StringSet(new RedisKey(key),new RedisValue ( stringContent), _RedisEndpoint.ConnectTimeout);
          }
          public bool Add<T>(string key, T value) where T : class
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               var stringContent = SerializeContent(value);
               return database.StringSet(new RedisKey(key), new RedisValue(stringContent), _RedisEndpoint.ConnectTimeout);
          }
          public bool Update(string key)
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               if (!database.KeyExists(key))
                    return false;
               var stringContent = database.StringGet(key);
               return database.StringSet(key, stringContent, _RedisEndpoint.ConnectTimeout);
          }
          public bool Update<T>(string key) where T : class
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               if (!database.KeyExists(key))
                    return false;
               RedisValue myString = database.StringGet(key);
               if (!myString.HasValue && myString.IsNullOrEmpty)
                    return false;               
               var stringContent = DeserializeContent<T>(myString);
               return database.StringSet(key, SerializeContent(stringContent), _RedisEndpoint.ConnectTimeout);
          }
          public string Get(string key)
          {
               using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
               IDatabase database = client.GetDatabase();
               RedisValue myString = database.StringGet(key);
               database.StringSet(key, myString, _RedisEndpoint.ConnectTimeout);
               return myString;
          }
          public T? Get<T>(string key) where T : class
          {
               try
               {
                    using ConnectionMultiplexer client = ConnectionMultiplexer.Connect($"{_RedisEndpoint.Url}:{_RedisEndpoint.Port}");
                    IDatabase database = client.GetDatabase();
                    RedisValue myString = database.StringGet(key);
                    if (myString.HasValue && !myString.IsNullOrEmpty)
                    {
                         database.StringSet(key, myString, _RedisEndpoint.ConnectTimeout);
                         return DeserializeContent<T>(myString);
                    }

                    return null;
               }
               catch (Exception)
               {
                    // Log Exception
                    return null;
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
