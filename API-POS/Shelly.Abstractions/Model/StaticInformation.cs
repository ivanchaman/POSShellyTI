using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class StaticInformation
     {
          public Branding Branding { get; set; }
          public List<CatalogsData> Catalogs { get; set; }
     }
}
