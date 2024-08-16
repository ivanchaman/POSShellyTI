
namespace Shelly.GraphQLCoreClient.Model
{
	public class ReservationsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("doctorId")]
		public long DoctorId{ get; set; }
		[JsonProperty("customerId")]
		public long CustomerId{ get; set; }
		[JsonProperty("serviceId")]
		public long ServiceId{ get; set; }
		[JsonProperty("promotionId")]
		public long PromotionId{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
