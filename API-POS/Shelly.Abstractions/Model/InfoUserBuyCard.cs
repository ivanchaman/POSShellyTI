using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoUserBuyCard
     {
          [JsonProperty("currencyId")]
          public int CurrencyId { get; set; }

          [JsonProperty("currencyName")]
          public string CurrencyName { get; set; }

          [JsonProperty("amountUSD")]
          public double AmountUSD { get; set; }

          [JsonProperty("amountCrypto")]
          public double AmountCrypto { get; set; }

          [JsonProperty("creditCard")]
          public InfoUserBuyCreditCard CreditCard { get; set; }
          [JsonProperty("reissueCard")]
          public UpgradeCard ReissueCard { get; set; }
          [JsonProperty("upgradeCard")]
          public UpgradeCard UpgradeCard { get; set; }
          [JsonProperty("cards")]
          public List<TiersCards> Cards { get; set; }

          private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

          [Newtonsoft.Json.JsonExtensionData]
          public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
          {
               get { return _additionalProperties; }
               set { _additionalProperties = value; }
          }
     }
}
