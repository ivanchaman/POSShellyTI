
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicDoctorSchedulesType : ObjectGraphType<DoctorSchedules>	{

	public MedicalClinicDoctorSchedulesType()
	{

		Name = "MedicalClinicDoctorSchedulesType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.DoctorId);
			Field(f => f.DayOfWeek);
			Field(f => f.StartTime);
			Field(f => f.EndTime);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
