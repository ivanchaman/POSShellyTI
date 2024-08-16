
namespace Shelly.GraphQLCoreClient.Model
{
	public class ErrorSystemResponse
	{
		[JsonProperty("id")]
		public string Id{ get; set; }
		[JsonProperty("type")]
		public int Type{ get; set; }
		[JsonProperty("headerDefinition")]
		public string HeaderDefinition{ get; set; }
		[JsonProperty("footherDefinition")]
		public string FootherDefinition{ get; set; }
		[JsonProperty("translationKey")]
		public string TranslationKey{ get; set; }
		[JsonProperty("defaultMessage")]
		public string DefaultMessage{ get; set; }

	}
}
