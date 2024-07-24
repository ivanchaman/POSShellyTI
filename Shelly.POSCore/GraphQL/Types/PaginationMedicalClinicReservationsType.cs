
namespace Shelly.POSCore.GraphQL.Types
{
	public class  PaginationMedicalClinicReservationsType : ObjectGraphType<Pagination<Reservations>>	{

	public PaginationMedicalClinicReservationsType()
	{

		Name = "PaginationMedicalClinicReservationsType";
		#region Fields

			Field(f => f.TotalRows);
			Field(f => f.PageNumber);
			Field(f => f.RowsOfPage);
			Field<ListGraphType<MedicalClinicReservationsType>>("Data");
		#endregion

	}
	}
}
