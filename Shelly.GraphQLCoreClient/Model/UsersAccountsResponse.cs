
namespace Shelly.GraphQLCoreClient.Model
{
	public class AccountsResponse
	{
		[JsonProperty("userNumber")]
		public long UserNumber{ get; set; }
		[JsonProperty("firstName")]
		public string FirstName{ get; set; }
		[JsonProperty("middleName")]
		public string MiddleName{ get; set; }
		[JsonProperty("lastName")]
		public string LastName{ get; set; }
		[JsonProperty("secondLastName")]
		public string SecondLastName{ get; set; }
		[JsonProperty("avatarImageId")]
		public long AvatarImageId{ get; set; }
		[JsonProperty("ssnNationalId")]
		public string SSNNationalId{ get; set; }
		[JsonProperty("birthday")]
		public string Birthday{ get; set; }
		[JsonProperty("gender")]
		public int Gender{ get; set; }
		[JsonProperty("nationality")]
		public int Nationality{ get; set; }
		[JsonProperty("placeOfBirth")]
		public int PlaceOfBirth{ get; set; }
		[JsonProperty("isComplete")]
		public bool IsComplete{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }
		[JsonProperty("useBillingToShipping")]
		public bool UseBillingToShipping{ get; set; }

	}
}
