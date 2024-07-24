using Shelly.Abstractions.Settings.Options;
using System;

namespace Shelly.Abstractions.Settings
{
     public class Local
     {
          public BlobStorages BlobStorages { get; set; }
          public Cache Cache { get; set; }
          public DataAccess DataAccess { get; set; }
          public Email Email { get; set; }
          public HttpServices HttpServices { get; set; }
          
          public Local()
          {
               BlobStorages = new BlobStorages();
               Cache = new Cache();
               DataAccess = new DataAccess();
               Email = new Email();
               HttpServices = new HttpServices();
          }
     }
}