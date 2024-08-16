
namespace Shelly.GraphQLCoreClient.Model
{
	public class EmailTemplatesResponse
	{
		[JsonProperty("company")]
		public int Company{ get; set; }
		[JsonProperty("language")]
		public int Language{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("htmlPart")]
		public string HtmlPart{ get; set; }
		[JsonProperty("subjectPart")]
		public string SubjectPart{ get; set; }
		[JsonProperty("textPart")]
		public string TextPart{ get; set; }
		[JsonProperty("parameters")]
		public string Parameters{ get; set; }

	}
}
