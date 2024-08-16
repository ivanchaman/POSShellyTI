
namespace Shelly.GraphQLCoreClient.Model
{
	public class SendEmailResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("providerID")]
		public int ProviderID{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("emailFrom")]
		public string EmailFrom{ get; set; }
		[JsonProperty("emailTo")]
		public string EmailTo{ get; set; }
		[JsonProperty("emailCC")]
		public string EmailCC{ get; set; }
		[JsonProperty("emailCCO")]
		public string EmailCCO{ get; set; }
		[JsonProperty("messageId")]
		public string MessageId{ get; set; }
		[JsonProperty("requestId")]
		public string RequestId{ get; set; }
		[JsonProperty("httpStatusCode")]
		public int HttpStatusCode{ get; set; }
		[JsonProperty("response")]
		public string Response{ get; set; }
		[JsonProperty("exception")]
		public string Exception{ get; set; }
		[JsonProperty("sendDate")]
		public DateTime SendDate{ get; set; }
		[JsonProperty("templateName")]
		public string TemplateName{ get; set; }
		[JsonProperty("message")]
		public string Message{ get; set; }

	}
}
