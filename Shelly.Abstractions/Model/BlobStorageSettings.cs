using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class BlobStorageSettings
     {                    
          public string? Usr { get; set; }
          public string? Pwd { get; set; }
          public string? Region { get; set; }          
          public string? Bucket { get; set; }
          public string? Acl { get; set; }

          public string? AccountName { get; set; }
          public string? AccountKey { get; set; }
          public string? ContainerName { get; set; }
     }
}
