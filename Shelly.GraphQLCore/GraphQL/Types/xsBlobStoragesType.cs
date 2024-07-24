namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class xsBlobStoragesType : ObjectGraphType<BlobStorages>
	{

		public xsBlobStoragesType()
		{

			Name = "xsBlobStoragesType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.UserNumber);
			Field(f => f.FileName);
			Field(f => f.FileExtension);
			Field(f => f.FileUrl);
			Field(f => f.BlobStorageName);
			Field(f => f.CreateAt);
			#endregion

		}
	}
}
