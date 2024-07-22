using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.GraphQL.Mutation
{
     public class Mutations : ObjectGraphType<object>
     {
          private BaseSystem _System;

          public Mutations(BaseSystem system) 
          {
               Name = "BasicMutations";
               _System = system;
               InitFieldsRegisterUser();
               InitFieldsRegisterCompany();
          }

          private void InitFieldsRegisterUser()
          {
               Field<Boolean>("setRegisterUser")
                    .Argument<NewUserInputType>("data")
                    .Resolve(setRegisterUser);
          }

          public void InitFieldsRegisterCompany()
          {
               Field<Boolean>("setRegisterCompany")
                    .Argument<NewCompanyInputType>("data")
                    .Resolve(setRegisterCompany);
          }

          private bool setRegisterUser(IResolveFieldContext context) => context.Try(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               Users users = new Users(_System);
               NewUser data = context.GetArgument<NewUser>("data");
               if (data == null)
                    throw new CoreException(Errors.E00000008);
               users.Load(x => x.UserName == data.UserName || x.Email == data.Email);
               if (!users.EOF)
                    throw new CoreException(Errors.E00000010);
               users.Add(data);
               return true;
          });

          private bool setRegisterCompany(IResolveFieldContext context) => context.Try(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               Companies company = new Companies(_System);
               NewCompany data = context.GetArgument<NewCompany>("data");
               company.Load(x => x.DisplayName == data.Name || x.Email == data.Email);
               if (!company.EOF)
                    throw new CoreException(Errors.E00000011);
               company.Add(data);
               return true;
          });
     }
}
