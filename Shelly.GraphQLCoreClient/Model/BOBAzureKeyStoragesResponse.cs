
namespace Shelly.GraphQLCoreClient.Model
{
	public class AzureKeyStoragesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("environment")]
		public int Environment{ get; set; }
		[JsonProperty("containerName")]
		public string ContainerName{ get; set; }
		[JsonProperty("accountName")]
		public string AccountName{ get; set; }
		[JsonProperty("accountKey")]
		public string AccountKey{ get; set; }
		[JsonProperty("status")]
		public bool Status{ get; set; }

	}
}
