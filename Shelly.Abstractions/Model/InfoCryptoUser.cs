using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoCryptoUser : InfoTrx
     {
          [JsonProperty("currencyIdSource", NullValueHandling = NullValueHandling.Ignore)]
          public int? CurrencyIdSource { get; set; }

          [JsonProperty("currencyIdDestine", NullValueHandling = NullValueHandling.Ignore)]
          public int? CurrencyIdDestine { get; set; }

          [JsonProperty("currencyId", NullValueHandling = NullValueHandling.Ignore)]
          public int? CurrencyId { get; set; }

          [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
          public string Address { get; set; }

          [JsonProperty("savingAccountId", NullValueHandling = NullValueHandling.Ignore)]
          public int? SavingAccountId { get; set; }

          [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
          public InfoCrypto From { get; set; }

          [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
          public InfoCrypto To { get; set; }


          private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

          [Newtonsoft.Json.JsonExtensionData]
          public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
          {
               get { return _additionalProperties; }
               set { _additionalProperties = value; }
          }
     }
}
