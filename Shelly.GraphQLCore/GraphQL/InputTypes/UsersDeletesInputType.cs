
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  UsersDeletesInputType : InputObjectGraphType<UsersDeletes>	{

	public UsersDeletesInputType()
	{

		Name = "UsersDeletesInputType";
		#region Fields

			Field(f => f.UserNumber);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
