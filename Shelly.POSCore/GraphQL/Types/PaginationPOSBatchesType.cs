
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSBatchesType : ObjectGraphType<Pagination<Batches>>	{

	public PaginationPOSBatchesType()
	{

		Name = "PaginationPOSBatchesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSBatchesType>>("Data");
		#endregion

	}
	}
}
