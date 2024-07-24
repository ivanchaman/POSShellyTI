
namespace Shelly.POSCore.GraphQL.InputTypes
{
	public class  MedicalClinicReservationsInputType : InputObjectGraphType<Reservations>	{

	public MedicalClinicReservationsInputType()
	{

		Name = "MedicalClinicReservationsInputType";
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
