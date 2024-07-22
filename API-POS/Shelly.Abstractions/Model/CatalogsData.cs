using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class CatalogsData
     {
         public long Id { get; set; }
          public string Name{ get; set; }
          public string Description{ get; set; }
          public double Version{ get; set; }
          public string Data{ get; set; }
     }
}
