
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSProductsTaxType : ObjectGraphType<Pagination<ProductsTax>>	{

	public PaginationPOSProductsTaxType()
	{

		Name = "PaginationPOSProductsTaxType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSProductsTaxType>>("Data");
		#endregion

	}
	}
}
