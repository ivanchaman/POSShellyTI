
namespace Shelly.GraphQLCoreClient.Model
{
	public class SuppliersResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("externalId")]
		public string ExternalId{ get; set; }
		[JsonProperty("displayName")]
		public string DisplayName{ get; set; }
		[JsonProperty("avatarImageId")]
		public long AvatarImageId{ get; set; }
		[JsonProperty("phoneCode")]
		public string PhoneCode{ get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber{ get; set; }
		[JsonProperty("email")]
		public string Email{ get; set; }
		[JsonProperty("countryCode")]
		public int CountryCode{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("rfc")]
		public string Rfc{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
