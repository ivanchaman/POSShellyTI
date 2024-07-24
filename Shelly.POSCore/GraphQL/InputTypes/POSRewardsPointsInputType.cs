
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSRewardsPointsInputType : InputObjectGraphType<RewardsPoints>	{

	public POSRewardsPointsInputType()
	{

		Name = "POSRewardsPointsInputType";
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
