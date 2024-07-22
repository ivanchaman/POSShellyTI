
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  POSUnitOfMeasureInputType : InputObjectGraphType<UnitOfMeasure>	{

	public POSUnitOfMeasureInputType()
	{

		Name = "POSUnitOfMeasureInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
