
namespace Shelly.GraphQLCoreClient.Model
{
	public class UsersResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("uuid")]
		public string Uuid{ get; set; }
		[JsonProperty("userName")]
		public string UserName{ get; set; }
		[JsonProperty("email")]
		public string Email{ get; set; }
		[JsonProperty("password")]
		public string Password{ get; set; }
		[JsonProperty("phoneCode")]
		public string PhoneCode{ get; set; }
		[JsonProperty("phoneNumber")]
		public string PhoneNumber{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("userTypeId")]
		public int UserTypeId{ get; set; }

	}
}
