namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class xsErrorSystemType : ObjectGraphType<ProviderData.Repository.Entity.ErrorSystem>
	{

		public xsErrorSystemType()
		{

			Name = "xsErrorSystemType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Type);
			Field(f => f.HeaderDefinition);
			Field(f => f.FootherDefinition);
			Field(f => f.TranslationKey);
			Field(f => f.DefaultMessage);
			#endregion

		}
	}
}
