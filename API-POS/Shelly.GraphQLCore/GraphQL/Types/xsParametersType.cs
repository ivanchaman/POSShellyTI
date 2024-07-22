namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class xsParametersType : ObjectGraphType<xsParameters>
	{

		public xsParametersType()
		{

			Name = "xsParametersType";
			#region Fields

			Field(f => f.Company);
			Field(f => f.Parameter);
			Field(f => f.Value);
			Field(f => f.Description);
			#endregion

		}
	}
}
