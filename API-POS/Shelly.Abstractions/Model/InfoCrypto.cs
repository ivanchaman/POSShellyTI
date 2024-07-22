using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoCrypto
     {
          [JsonProperty("currencyId")]
          public int CurrencyId { get; set; }
          [JsonProperty("currencyName", NullValueHandling = NullValueHandling.Ignore)]
          public string CurrencyName { get; set; }
          [JsonProperty("shortName", NullValueHandling = NullValueHandling.Ignore)]
          public string ShortName { get; set; }
          [JsonProperty("amountCrypto", NullValueHandling = NullValueHandling.Ignore)]
          public double? AmountCrypto { get; set; }
          [JsonProperty("amountUSD", NullValueHandling = NullValueHandling.Ignore)]
          public double? AmountUSD { get; set; }

          [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
          public string Address { get; set; }

          [JsonProperty("decimal", NullValueHandling = NullValueHandling.Ignore)]
          public double? Decimals { get; set; }

          [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
          public InfoUser User { get; set; }
     }
}
