
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSRewardsPointsType : ObjectGraphType<RewardsPoints>	{

	public POSRewardsPointsType()
	{

		Name = "POSRewardsPointsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.WalletId);
			Field(f => f.TransactionType);
			Field(f => f.Amount);
			Field(f => f.SourceTrxId);
			Field(f => f.Description);
			Field(f => f.Pool);
			Field(f => f.MetaData);
			Field(f => f.FeeId);
			Field(f => f.CreatedAt);
			Field(f => f.HashId);
		#endregion

	}
	}
}
