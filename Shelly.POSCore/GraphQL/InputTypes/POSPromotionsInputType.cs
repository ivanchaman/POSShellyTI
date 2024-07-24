﻿
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSPromotionsInputType : InputObjectGraphType<Promotions>	{

	public POSPromotionsInputType()
	{

		Name = "POSPromotionsInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.Name);
			Field(f => f.StartDate);
			Field(f => f.EndDate);
			Field(f => f.DiscountPercentage);
			Field(f => f.CreatedAt);
			Field(f => f.Type);
			Field(f => f.Status);
		#endregion

	}
	}
}