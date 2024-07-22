
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicReservationsType : ObjectGraphType<Reservations>	{

	public MedicalClinicReservationsType()
	{

		Name = "MedicalClinicReservationsType";
		#region Fields

			Field(f => f.Id);
			Field(f => f.Company);
			Field(f => f.DoctorId);
			Field(f => f.CustomerId);
			Field(f => f.ServiceId);
			Field(f => f.PromotionId);
			Field(f => f.Status);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
