
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSPromotionsProductInputType : InputObjectGraphType<PromotionsProduct>	{

	public POSPromotionsProductInputType()
	{

		Name = "POSPromotionsProductInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.PromotionId);
			Field(f => f.ProductId);
		#endregion

	}
	}
}
