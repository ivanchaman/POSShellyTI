namespace Shelly.POSCore.GraphQL.InputTypes
{
     internal class MedicalClinicPatientsWeightLossInputType : InputObjectGraphType<PatientsWeightLoss>
     {

          public MedicalClinicPatientsWeightLossInputType()
          {

               Name = "MedicalClinicPatientsWeightLossInputType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.CustomerId);
               Field(f => f.Waist);
               Field(f => f.Hip);
               Field(f => f.Weight);
               Field(f => f.BMI);
               Field(f => f.FatPercentage);
               Field(f => f.ViceralFatPercentage);
               Field(f => f.MusclePercentage);
               Field(f => f.WaterPercentage);
               Field(f => f.BonePercentage);
               Field(f => f.ProteinPercentage);
               Field(f => f.Metabolism);
               Field(f => f.PhysicalAge);
               Field(f => f.BiologicalAge);
               Field(f => f.CreatedAt);
               #endregion

          }
     }
}
