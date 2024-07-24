
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSPromotionsProductType : ObjectGraphType<Pagination<PromotionsProduct>>	{

	public PaginationPOSPromotionsProductType()
	{

		Name = "PaginationPOSPromotionsProductType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSPromotionsProductType>>("Data");
		#endregion

	}
	}
}
