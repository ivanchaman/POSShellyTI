
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  UsersBlackListInputType : InputObjectGraphType<UsersBlackList>	{

	public UsersBlackListInputType()
	{

		Name = "UsersBlackListInputType";
		#region Fields

			Field(f => f.UserNumber);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
