namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	internal class UsersSecurityInputType : InputObjectGraphType<UsersSecurity>
	{

		public UsersSecurityInputType()
		{

			Name = "UsersSecurityInputType";
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
