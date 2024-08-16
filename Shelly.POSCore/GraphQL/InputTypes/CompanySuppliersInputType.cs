
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class CompanySuppliersInputType : InputObjectGraphType<Suppliers>
	{

		public CompanySuppliersInputType()
		{

			Name = "CompanySuppliersInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.ExternalId);
			Field(f => f.DisplayName);
			Field(f => f.AvatarImageId);
			Field(f => f.PhoneCode);
			Field(f => f.PhoneNumber);
			Field(f => f.Email);
			Field(f => f.CountryCode);
			Field(f => f.Status);
			Field(f => f.Rfc);
			Field(f => f.CreatedAt);
			#endregion

		}
	}
}
