
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicPatientsExplorationInputType : InputObjectGraphType<PatientsExploration>	{

	public MedicalClinicPatientsExplorationInputType()
	{

		Name = "MedicalClinicPatientsExplorationInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.MedicalServicesId);
			Field(f => f.Type);
			Field(f => f.Observations);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
