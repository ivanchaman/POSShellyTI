
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicExplorationTypeType : ObjectGraphType<ExplorationType>	{

	public MedicalClinicExplorationTypeType()
	{

		Name = "MedicalClinicExplorationTypeType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
