namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class NewCompanyInputType : InputObjectGraphType<NewCompany>
     {
          public NewCompanyInputType()
          {
               Name = "NewCompanyInputType";
               Field(f => f.Name);
               Field(f => f.Email);
               Field(f => f.PhoneCode);
               Field(f => f.PhoneNumber);
          }
     }
}
