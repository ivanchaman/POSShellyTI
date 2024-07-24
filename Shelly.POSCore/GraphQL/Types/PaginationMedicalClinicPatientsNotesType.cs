
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicPatientsNotesType : ObjectGraphType<Pagination<PatientsNotes>>	{

	public PaginationMedicalClinicPatientsNotesType()
	{

		Name = "PaginationMedicalClinicPatientsNotesType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientsNotesType>>("Data");
		#endregion

	}
	}
}
