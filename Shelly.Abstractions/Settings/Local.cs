using Shelly.Abstractions.Settings.Options;
using System;

namespace Shelly.Abstractions.Settings
{
     public class Local
     {
          public const string SectionKey = "AppSettings";
          public int Company { get; set; }
          public string APIUrl { get; set; }
          public string NPublicKey { get; set; }
          public string NPrivatekey { get; set; }
          public string DBPublicKey { get; set; }
          public string DBPrivatekey { get; set; }

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