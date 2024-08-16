
namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
	public class  CompanyCompaniesInputType : InputObjectGraphType<Companies>	{

	public CompanyCompaniesInputType()
	{

		Name = "CompanyCompaniesInputType";
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
			Field(f => f.Rfc);
			Field(f => f.SATCertificate);
			Field(f => f.SATPrivateKey);
			Field(f => f.SATPwd);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
