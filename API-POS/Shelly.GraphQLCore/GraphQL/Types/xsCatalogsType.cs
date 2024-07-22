namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsCatalogsType : ObjectGraphType<Catalogs>
	{

		public xsCatalogsType()
		{

			Name = "xsCatalogsType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.Version);
			Field(f => f.Data);
			#endregion

		}
	}
}
