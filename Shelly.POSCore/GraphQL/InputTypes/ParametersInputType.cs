
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  ParametersInputType : InputObjectGraphType<Shelly.ProviderData.Repository.Entity.xsParameters>	{

	public ParametersInputType()
	{

		Name = "ParametersInputType";
		#region Fields

			Field(f => f.Company);
			Field(f => f.Parameter);
			Field(f => f.Value);
			Field(f => f.Description);
		#endregion

	}
	}
}
