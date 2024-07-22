using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.ProviderBlobStorages.Model
{
    internal class AWSBlobStorageSettings
    {
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Region { get; set; }
        public string? Bucket { get; set; }
        public string? Acl { get; set; }
    }
}
