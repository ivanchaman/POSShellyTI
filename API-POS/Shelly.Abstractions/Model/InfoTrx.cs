using Newtonsoft.Json;

namespace Shelly.Abstractions.Model
{
     public class InfoTrx
     {
          [JsonProperty("txHash", NullValueHandling = NullValueHandling.Ignore)]
          public string TxHash { get; set; }

          [JsonProperty("networkFee", NullValueHandling = NullValueHandling.Ignore)]
          public double? NetworkFee { get; set; }

          [JsonProperty("walletFeeUsd", NullValueHandling = NullValueHandling.Ignore)]
          public double? WalletFeeUsd { get; set; }
          [JsonProperty("walletFeeCrypto", NullValueHandling = NullValueHandling.Ignore)]
          public double? WalletFeeCrypto { get; set; }

          [JsonProperty("isDirectExchange", NullValueHandling = NullValueHandling.Ignore)]
          public bool? IsDirectExchange { get; set; }

     }
}
