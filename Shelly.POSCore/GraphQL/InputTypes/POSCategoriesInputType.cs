
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class POSCategoriesInputType : InputObjectGraphType<Categories>
	{

		public POSCategoriesInputType()
		{

			Name = "POSCategoriesInputType";
			#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.CreatedAt);
			#endregion

		}
	}
}
