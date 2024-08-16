
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class MedicalClinicDoctorSchedulesInputType : InputObjectGraphType<DoctorSchedules>
	{

		public MedicalClinicDoctorSchedulesInputType()
		{

			Name = "MedicalClinicDoctorSchedulesInputType";
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
