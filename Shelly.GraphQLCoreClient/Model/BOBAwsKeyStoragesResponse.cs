
namespace Shelly.GraphQLCoreClient.Model
{
	public class AwsKeyStoragesResponse
	{
		[JsonProperty("id")]
		public long Id { get; set; }
		[JsonProperty("environment")]
		public int Environment { get; set; }
		[JsonProperty("usr")]
		public string Usr { get; set; }
		[JsonProperty("pwd")]
		public string Pwd { get; set; }
		[JsonProperty("region")]
		public string Region { get; set; }
		[JsonProperty("bucket")]
		public string Bucket { get; set; }
		[JsonProperty("acl")]
		public string Acl { get; set; }
		[JsonProperty("status")]
		public bool Status { get; set; }

	}
}
