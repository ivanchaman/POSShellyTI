namespace Shelly.GraphQLCore.GraphQL.Types
{
	internal class UsersSecurityType : ObjectGraphType<UsersSecurity>
	{

		public UsersSecurityType()
		{

			Name = "UsersSecurityType";
			#region Fields

			Field(f => f.UserNumber);
			Field(f => f.Id);
			Field(f => f.KeyValue);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
			#endregion

		}
	}
}
