
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientsLaboratoriesType : ObjectGraphType<PatientsLaboratories>	{

	public MedicalClinicPatientsLaboratoriesType()
	{

		Name = "MedicalClinicPatientsLaboratoriesType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.MedicalServicesId);
			Field(f => f.Description);
			Field(f => f.Status);
			Field(f => f.ImageId);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
