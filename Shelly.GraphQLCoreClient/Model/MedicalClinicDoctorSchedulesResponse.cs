
namespace Shelly.GraphQLCoreClient.Model
{
	public class DoctorSchedulesResponse
	{
		[JsonProperty("id")]
		public long Id { get; set; }
		[JsonProperty("company")]
		public long Company { get; set; }
		[JsonProperty("doctorId")]
		public long DoctorId { get; set; }
		[JsonProperty("dayOfWeek")]
		public int DayOfWeek { get; set; }
		[JsonProperty("startTime")]
		public DateTime StartTime { get; set; }
		[JsonProperty("endTime")]
		public DateTime EndTime { get; set; }
		[JsonProperty("status")]
		public int Status { get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt { get; set; }

	}
}
