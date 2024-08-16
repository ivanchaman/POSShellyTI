using Shelly.POSCore.GraphQL.InputTypes;

namespace Shelly.POSCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations
     {
          public void FieldsCommon()
          {
               Field<Boolean>("setSuppliers")
                    .Argument<CompanySuppliersInputType>("data")
                    .Resolve(SetSuppliers);
               Field<Boolean>("setSuppliersAddress")
                    .Argument<CompanySuppliersAddressInputType>("data")
                    .Resolve(SetSuppliersAddress);
          }
          private bool SetSuppliers(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Suppliers data = new(_System);
               data.Add(context.GetArgument<Suppliers>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetSuppliersAddress(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               SuppliersAddress data = new(_System);
               data.Add(context.GetArgument<SuppliersAddress>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
     }
}
