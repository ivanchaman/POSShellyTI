
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSPromotionsProductType : ObjectGraphType<PromotionsProduct>	{

	public POSPromotionsProductType()
	{

		Name = "POSPromotionsProductType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.PromotionId);
			Field(f => f.ProductId);
		#endregion

	}
	}
}
