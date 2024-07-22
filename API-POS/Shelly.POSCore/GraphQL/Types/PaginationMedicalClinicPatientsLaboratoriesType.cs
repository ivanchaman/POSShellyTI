
namespace Shelly.POSCore.GraphQL.Types
{
	public class PaginationMedicalClinicPatientsLaboratoriesType : ObjectGraphType<Pagination<PatientsLaboratories>>
	{

		public PaginationMedicalClinicPatientsLaboratoriesType()
		{

			Name = "PaginationMedicalClinicPatientsLaboratoriesType";
			#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicPatientsLaboratoriesType>>("Data");
			#endregion

		}
	}
}
