
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSPromotionsType : ObjectGraphType<Pagination<Promotions>>	{

	public PaginationPOSPromotionsType()
	{

		Name = "PaginationPOSPromotionsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSPromotionsType>>("Data");
		#endregion

	}
	}
}
