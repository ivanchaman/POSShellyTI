
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  CatalogsInputType : InputObjectGraphType<Catalogs>	{

	public CatalogsInputType()
	{

		Name = "CatalogsInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.Version);
		#endregion

	}
	}
}
