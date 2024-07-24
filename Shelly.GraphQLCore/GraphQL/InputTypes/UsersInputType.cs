namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class UsersInputType : InputObjectGraphType<Users>
	{

		public UsersInputType()
		{

			Name = "UsersInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Uuid);
			Field(f => f.UserName);
			Field(f => f.Email);
			Field(f => f.Password);
			Field(f => f.PhoneCode);
			Field(f => f.PhoneNumber);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
			#endregion

		}
	}
}
