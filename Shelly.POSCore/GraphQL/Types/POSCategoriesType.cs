
namespace Shelly.POSCore.GraphQL.Types
{
	public class POSCategoriesType : ObjectGraphType<Categories>
	{

		public POSCategoriesType()
		{

			Name = "POSCategoriesType";
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
