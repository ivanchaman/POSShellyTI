
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicPatientsLaboratoriesInputType : InputObjectGraphType<PatientsLaboratories>	{

	public MedicalClinicPatientsLaboratoriesInputType()
	{

		Name = "MedicalClinicPatientsLaboratoriesInputType";
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
