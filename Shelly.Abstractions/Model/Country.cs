using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class Country
     {
          public int Id { get; set; }
          public string Nombre { get; set; }
          public string Name { get; set; }
          public string Nom { get; set; }
          public string Iso2 { get; set; }
          public string Iso3 { get; set; }
          public string Iso4217 { get; set; }
          public string AbvMoneda { get; set; }
          public string PhoneCode { get; set; }
          public bool Status { get; set; }
          public string Emoji { get; set; }
          public string Icon { get; set; }
          public string Capital { get; set; }
          public string States { get; set; }
          public string Region { get; set; }
         
     }
}
