namespace Shelly.GraphQLCore.GraphQL.Mutation.Dashboard
{
     public partial class Mutations
     {
          public void FieldsSettings()
          {
               Field<Boolean>("setAzureKeyStorages")
                    .Argument<BOBAzureKeyStoragesInputType>("data")
                    .Resolve(SetAzureKeyStorages);

               Field<Boolean>("setAwsKeyStorages")
                    .Argument<BOBAwsKeyStoragesInputType>("data")
                    .Resolve(SetAwsKeyStorages);
          }

          private bool SetAzureKeyStorages(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               AzureKeyStorages data = new(_System);
               data.Add(context.GetArgument<AzureKeyStorages>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetAwsKeyStorages(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               AwsKeyStorages data = new(_System);
               data.Add(context.GetArgument<AwsKeyStorages>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
     }
}
