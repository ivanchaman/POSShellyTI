using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.ProviderCache.Model
{
     public class RedisClientConfigurations
     {
          public string Url { get; set; }
          public int Port { get; set; }
          public TimeSpan ConnectTimeout { get; set; }
     }
}
