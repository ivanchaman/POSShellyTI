
namespace Shelly.POSCore.GraphQL.Types
{
	public class  MedicalClinicPatientsNotesType : ObjectGraphType<PatientsNotes>	{

	public MedicalClinicPatientsNotesType()
	{

		Name = "MedicalClinicPatientsNotesType";
		#region Fields

			Field(f => f.MedicalServicesId);
			Field(f => f.Reasons);
			Field(f => f.PEEA);
			Field(f => f.LaboratoryResults);
			Field(f => f.Diagnostics);
			Field(f => f.Remarks);
			Field(f => f.Forecasts);
			Field(f => f.HeartRate);
			Field(f => f.RespiratoryRate);
			Field(f => f.Oximetry);
			Field(f => f.Temperature);
			Field(f => f.ArterialTension);
			Field(f => f.Height);
			Field(f => f.Weight);
			Field(f => f.Waist);
			Field(f => f.Hip);
			Field(f => f.BMI);
			Field(f => f.Recommendations);
			Field(f => f.CreatedAt);
		#endregion

	}
	}
}
