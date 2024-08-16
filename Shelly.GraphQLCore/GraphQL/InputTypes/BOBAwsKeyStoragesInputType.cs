
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class BOBAwsKeyStoragesInputType : InputObjectGraphType<AwsKeyStorages>
	{

		public BOBAwsKeyStoragesInputType()
		{

			Name = "BOBAwsKeyStoragesInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Environment);
			Field(f => f.Usr);
			Field(f => f.Pwd);
			Field(f => f.Region);
			Field(f => f.Bucket);
			Field(f => f.Acl);
			Field(f => f.Status);
			#endregion

		}
	}
}
