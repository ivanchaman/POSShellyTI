
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class UsersUserTypeInputType : InputObjectGraphType<Shelly.ProviderData.Repository.Entity.UsersType>
	{

		public UsersUserTypeInputType()
		{

			Name = "UsersUserTypeInputType";
			#region Fields

			Field(f => f.ID);
			Field(f => f.Type);
			Field(f => f.Active);
			#endregion

		}
	}
}
