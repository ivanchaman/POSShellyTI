namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsCatalogsDetailType : ObjectGraphType<ProviderData.Repository.Entity.CatalogsDetail>
	{

		public xsCatalogsDetailType()
		{

			Name = "xsCatalogsDetailType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			#endregion

		}
	}
}
