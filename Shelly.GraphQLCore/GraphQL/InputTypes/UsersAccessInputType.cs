
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  UsersAccessInputType : InputObjectGraphType<UsersAccess>	{

	public UsersAccessInputType()
	{

		Name = "UsersAccessInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.UserNumber);
			Field(f => f.Product);
			Field(f => f.DateAccess);
			Field(f => f.Status);
		#endregion

	}
	}
}
