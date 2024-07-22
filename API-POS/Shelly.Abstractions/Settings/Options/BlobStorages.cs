using System.Security.Cryptography.X509Certificates;

namespace Shelly.Abstractions.Settings.Options
{
     public class BlobStorages
     {
          public const string SectionKey = "BlobStorages";
          public int Enviroment { get; set; }
          public int BlobStorageType { get; set; }        
     }
}
