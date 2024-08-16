
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class BOBAzureKeyStoragesInputType : InputObjectGraphType<AzureKeyStorages>
	{

		public BOBAzureKeyStoragesInputType()
		{

			Name = "BOBAzureKeyStoragesInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Environment);
			Field(f => f.ContainerName);
			Field(f => f.AccountName);
			Field(f => f.AccountKey);
			Field(f => f.Status);
			#endregion

		}
	}
}
