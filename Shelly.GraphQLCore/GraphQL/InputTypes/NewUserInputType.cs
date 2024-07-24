namespace Shelly.GraphQLCore.GraphQL.InputTypes
{
     internal class NewUserInputType : InputObjectGraphType<NewUser>
     {
          public NewUserInputType()
          {
               Name = "NewUserInputType";
               Field(f => f.UserName);
               Field(f => f.Type);
               Field(f => f.Company);
               Field(f => f.Password);
               Field(f => f.FirstName);
               Field(f => f.LastName);
               Field(f => f.Email);
               Field(f => f.PhoneCode);
               Field(f => f.PhoneNumber);               
          }
     }
}
