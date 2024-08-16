
namespace Shelly.GraphQLCoreClient.Model
{
	public class CountriesResponse
	{
		[JsonProperty("id")]
		public int Id{ get; set; }
		[JsonProperty("nombre")]
		public string Nombre{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("nom")]
		public string Nom{ get; set; }
		[JsonProperty("iso2")]
		public string Iso2{ get; set; }
		[JsonProperty("iso3")]
		public string Iso3{ get; set; }
		[JsonProperty("iso4217")]
		public string Iso4217{ get; set; }
		[JsonProperty("abvMoneda")]
		public string AbvMoneda{ get; set; }
		[JsonProperty("phoneCode")]
		public string PhoneCode{ get; set; }
		[JsonProperty("status")]
		public bool Status{ get; set; }
		[JsonProperty("emoji")]
		public string Emoji{ get; set; }
		[JsonProperty("icon")]
		public string Icon{ get; set; }
		[JsonProperty("capital")]
		public string Capital{ get; set; }
		[JsonProperty("states")]
		public string States{ get; set; }
		[JsonProperty("region")]
		public string Region{ get; set; }
		[JsonProperty("isEnabled")]
		public bool IsEnabled{ get; set; }
		[JsonProperty("needs2Ids")]
		public bool Needs2Ids{ get; set; }

	}
}
