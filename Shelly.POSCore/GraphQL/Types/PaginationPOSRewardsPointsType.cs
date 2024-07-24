
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSRewardsPointsType : ObjectGraphType<Pagination<RewardsPoints>>	{

	public PaginationPOSRewardsPointsType()
	{

		Name = "PaginationPOSRewardsPointsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSRewardsPointsType>>("Data");
		#endregion

	}
	}
}
