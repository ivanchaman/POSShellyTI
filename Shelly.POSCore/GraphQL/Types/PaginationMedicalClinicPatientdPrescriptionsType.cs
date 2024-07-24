
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicPatientdPrescriptionsType : ObjectGraphType<Pagination<PatientdPrescriptions>>	{

	public PaginationMedicalClinicPatientdPrescriptionsType()
	{

		Name = "PaginationMedicalClinicPatientdPrescriptionsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientdPrescriptionsType>>("Data");
		#endregion

	}
	}
}
