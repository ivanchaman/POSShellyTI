
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientsHistoryType : ObjectGraphType<PatientsHistory>	{

	public MedicalClinicPatientsHistoryType()
	{

		Name = "MedicalClinicPatientsHistoryType";
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
