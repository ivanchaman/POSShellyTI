
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSSaleTaxDetailsType : ObjectGraphType<Pagination<SaleTaxDetails>>	{

	public PaginationPOSSaleTaxDetailsType()
	{

		Name = "PaginationPOSSaleTaxDetailsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSSaleTaxDetailsType>>("Data");
		#endregion

	}
	}
}
