
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class CatalogsDetailInputType : InputObjectGraphType<Shelly.ProviderData.Repository.Entity.CatalogsDetail>
	{

		public CatalogsDetailInputType()
		{

			Name = "CatalogsDetailInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.Status);
			Field(f => f.CatalogId);
			#endregion

		}
	}
}
