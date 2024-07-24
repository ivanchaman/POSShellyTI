
namespace Shelly.POSCore.GraphQL.Types
{
	public class  POSUnitOfMeasureType : ObjectGraphType<UnitOfMeasure>	{

	public POSUnitOfMeasureType()
	{

		Name = "POSUnitOfMeasureType";
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
