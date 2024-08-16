namespace Shelly.GraphQLCore.GraphQL.Mutation.Dashboard
{
     public partial class Mutations
     {
          public void FieldsCompanies()
          {
               Field<Boolean>("setCompanies")
                    .Argument<CompanyCompaniesInputType>("data")
                    .Resolve(SetCompanies);
               Field<Boolean>("setCompanyAddress")
                    .Argument<CompanyAddressInputType>("data")
                    .Resolve(SetAddress);
               
          }

          private bool SetAddress(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               CompaniesAddress data = new(_System);
               data.Add(context.GetArgument<CompaniesAddress>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetCompanies(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Companies data = new(_System);
               data.Add(context.GetArgument<Companies>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
         

     }
}
