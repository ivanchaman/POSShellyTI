
namespace Shelly.GraphQLCoreClient.Model
{
	public class ProductsResponse
	{
		[JsonProperty("id")]
		public long Id{ get; set; }
		[JsonProperty("company")]
		public long Company{ get; set; }
		[JsonProperty("barCode")]
		public string BarCode{ get; set; }
		[JsonProperty("name")]
		public string Name{ get; set; }
		[JsonProperty("description")]
		public string Description{ get; set; }
		[JsonProperty("categoryId")]
		public long CategoryId{ get; set; }
		[JsonProperty("unitOfMeasureId")]
		public long UnitOfMeasureId{ get; set; }
		[JsonProperty("satProductCode")]
		public string SATProductCode{ get; set; }
		[JsonProperty("satUnitCode")]
		public string SATUnitCode{ get; set; }
		[JsonProperty("imageId")]
		public long ImageId{ get; set; }
		[JsonProperty("status")]
		public int Status{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt{ get; set; }

	}
}
