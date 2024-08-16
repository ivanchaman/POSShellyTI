
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class CompanySuppliersAddressInputType : InputObjectGraphType<SuppliersAddress>
	{

		public CompanySuppliersAddressInputType()
		{

			Name = "CompanySuppliersAddressInputType";
			#region Fields

			Field(f => f.SupplierId);
			Field(f => f.Id);
			Field(f => f.City);
			Field(f => f.Country);
			Field(f => f.State);
			Field(f => f.Street);
			Field(f => f.ZipCode);
			Field(f => f.IsComplete);
			Field(f => f.CreatedAt);
			#endregion

		}
	}
}
