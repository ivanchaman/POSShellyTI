
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientsExplorationType : ObjectGraphType<PatientsExploration>	{

	public MedicalClinicPatientsExplorationType()
	{

		Name = "MedicalClinicPatientsExplorationType";
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
