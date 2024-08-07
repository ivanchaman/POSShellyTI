namespace Shelly.POSCore.GraphQL.InputTypes
{
     internal class MedicalClinicLaboratoriesTypeInputType : InputObjectGraphType<LaboratoriesType>
     {

          public MedicalClinicLaboratoriesTypeInputType()
          {

               Name = "MedicalClinicLaboratoriesTypeInputType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.Name);
               Field(f => f.Status);
               Field(f => f.CreatedAt);
               #endregion

          }
     }
}
