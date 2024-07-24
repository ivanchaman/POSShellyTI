
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicPatientsHistoryInputType : InputObjectGraphType<PatientsHistory>	{

	public MedicalClinicPatientsHistoryInputType()
	{

		Name = "MedicalClinicPatientsHistoryInputType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.CustomerId);
			Field(f => f.Type);
			Field(f => f.Name);
			Field(f => f.Familiar);
			Field(f => f.Status);
			Field(f => f.Diagnostico);
		#endregion

	}
	}
}
