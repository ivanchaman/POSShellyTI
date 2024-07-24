
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationPOSMedicationDetailsType : ObjectGraphType<Pagination<MedicationDetails>>	{

	public PaginationPOSMedicationDetailsType()
	{

		Name = "PaginationPOSMedicationDetailsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<POSMedicationDetailsType>>("Data");
		#endregion

	}
	}
}
