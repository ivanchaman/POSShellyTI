
namespace Shelly.GraphQLCoreClient.Model
{
	public class BlobStoragesResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("fileName")]
		public string FileName{ get; set; }
		[JsonProperty("fileExtension")]
		public string FileExtension{ get; set; }
		[JsonProperty("fileUrl")]
		public string FileUrl{ get; set; }
		[JsonProperty("blobStorageName")]
		public string BlobStorageName{ get; set; }
		[JsonProperty("createAt")]
		public DateTime CreateAt{ get; set; }

	}
}
