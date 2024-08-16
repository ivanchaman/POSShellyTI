
namespace Shelly.GraphQLCoreClient.Model
{
	public class RewardsPointsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("walletId")]
		public long WalletId{ get; set; }
		[JsonProperty("transactionType")]
		public int TransactionType{ get; set; }
		[JsonProperty("amount")]
		public double Amount{ get; set; }
		[JsonProperty("sourceTrxId")]
		public long SourceTrxId{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("pool")]
		public int Pool{ get; set; }
		[JsonProperty("metaData")]
		public string MetaData{ get; set; }
		[JsonProperty("feeId")]
		public int FeeId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("hashId")]
		public string HashId{ get; set; }

	}
}
