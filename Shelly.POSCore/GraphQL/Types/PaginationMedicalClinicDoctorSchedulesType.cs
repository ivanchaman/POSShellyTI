
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicDoctorSchedulesType : ObjectGraphType<Pagination<DoctorSchedules>>	{

	public PaginationMedicalClinicDoctorSchedulesType()
	{

		Name = "PaginationMedicalClinicDoctorSchedulesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicDoctorSchedulesType>>("Data");
		#endregion

	}
	}
}
