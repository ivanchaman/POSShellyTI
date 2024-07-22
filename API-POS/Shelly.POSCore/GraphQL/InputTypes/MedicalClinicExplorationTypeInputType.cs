
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicExplorationTypeInputType : InputObjectGraphType<ExplorationType>	{

	public MedicalClinicExplorationTypeInputType()
	{

		Name = "MedicalClinicExplorationTypeInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Name);
			Field(f => f.Description);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
