using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelly.Abstractions.Model
{
     public class EmailData
     {
          public string Nombre { get; set; }
          public string Mensaje { get; set; }
          public  string Email { get; set; }
     }

     public class Content
     {
          [JsonProperty("type")]
          public string type;

          [JsonProperty("value")]
          public string value;
     }

     public class From
     {
          [JsonProperty("email")]
          public string email;
     }

     public class Personalization
     {
          [JsonProperty("to")]
          public List<To> to;
     }

     public class Root
     {
          [JsonProperty("personalizations")]
          public List<Personalization> personalizations;

          [JsonProperty("from")]
          public From from;

          [JsonProperty("subject")]
          public string subject;

          [JsonProperty("content")]
          public List<Content> content;
     }

     public class To
     {
          [JsonProperty("email")]
          public string email;
     }
}
