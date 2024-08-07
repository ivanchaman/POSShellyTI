namespace Shelly.POSCore.GraphQL.InputTypes
{
     internal class MedicalClinicLaboratoriesInputType : InputObjectGraphType<Laboratories>
     {

          public MedicalClinicLaboratoriesInputType()
          {

               Name = "MedicalClinicLaboratoriesInputType";
               #region Fields

               Field(f => f.Id);
               Field(f => f.Name);
               Field(f => f.Status);
               Field(f => f.CreatedAt);
               #endregion

          }
     }
}
