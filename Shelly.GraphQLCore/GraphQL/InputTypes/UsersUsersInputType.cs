
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  UsersUsersInputType : InputObjectGraphType<Users>	{

	public UsersUsersInputType()
	{

		Name = "UsersUsersInputType";
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
			Field(f => f.UserTypeId);
		#endregion

	}
	}
}
