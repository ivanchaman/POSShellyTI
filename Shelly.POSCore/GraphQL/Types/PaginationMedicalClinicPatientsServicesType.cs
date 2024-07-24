
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicPatientsServicesType : ObjectGraphType<Pagination<PatientsServices>>	{

	public PaginationMedicalClinicPatientsServicesType()
	{

		Name = "PaginationMedicalClinicPatientsServicesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientsServicesType>>("Data");
		#endregion

	}
	}
}
