using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoUserBuyCreditCard
     {
          [JsonProperty("id")]
          public int Id { get; set; }
          [JsonProperty("saveCard")]
          public bool SaveCard { get; set; }

          [JsonProperty("firstName")]
          public string FirstName { get; set; }

          [JsonProperty("lastName")]
          public string LastName { get; set; }

          [JsonProperty("address1")]
          public string Address1 { get; set; }

          [JsonProperty("city")]
          public string City { get; set; }

          [JsonProperty("state")]
          public string State { get; set; }
          [JsonProperty("zip")]
          public string Zip { get; set; }
          [JsonProperty("cardNumber")]
          public string CardNumber { get; set; }
          [JsonProperty("cardMonthExpiration")]
          public int CardMonthExpiration { get; set; }
          [JsonProperty("cardYearExpiration")]
          public int CardYearExpiration { get; set; }
          [JsonProperty("cvv")]
          public string CVV { get; set; }

          //[JsonProperty("cards")]
          //public List<TiersCards> Cards { get; set; }
     }
}
