namespace Shelly.GraphQLCore.GraphQL.Types
{
     internal class CompanyType : ObjectGraphType<Companies>
	{

		public CompanyType()
		{

			Name = "CompanyType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.ExternalId);
			Field(f => f.DisplayName);
			Field(f => f.AvatarImageId);
			Field(f => f.PhoneCode);
			Field(f => f.PhoneNumber);
			Field(f => f.Email);
			Field(f => f.CountryCode);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
               Field(f => f.Version);
               Field<ListGraphType<DictionaryValueType>>("DataVersion");
			Field<xsBlobStoragesType>("ImageData");
               #endregion

          }
	}
}
