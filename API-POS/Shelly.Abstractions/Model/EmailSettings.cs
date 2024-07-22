using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class EmailSettings
     {
          public int Type { get; set; }
          public string From { get; set; }
          public string? User { get; set; }
          public string? Password { get; set; }
          public string? Region { get; set; }

          public bool IsSendEmail { get; set; }
          public bool IsSendEmailTest { get; set; }
     }
}
