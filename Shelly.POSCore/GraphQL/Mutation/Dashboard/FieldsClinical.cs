using Shelly.POSCore.GraphQL.InputTypes;

namespace Shelly.POSCore.GraphQL.Mutation.Dashboard
{
     internal partial class Mutations
     {
          public void FieldsClinical()
          {
               Field<Boolean>("setUnitOfMeasure")
                    .Argument<POSUnitOfMeasureInputType>("data")
                    .Resolve(SetUnitOfMeasure);
               Field<Boolean>("setRewardsPoints")
                    .Argument<POSRewardsPointsInputType>("data")
                    .Resolve(SetRewardsPoints);
               Field<Boolean>("setTaxes")
                    .Argument<POSTaxesInputType>("data")
                    .Resolve(SetTaxes);
               Field<Boolean>("setSimpleReceipts")
                    .Argument<POSSimpleReceiptsInputType>("data")
                    .Resolve(SetSimpleReceipts);
               Field<Boolean>("setSalesDetails")
                    .Argument<POSSalesDetailsInputType>("data")
                    .Resolve(SetSalesDetails);
               Field<Boolean>("setBatches")
                    .Argument<POSBatchesInputType>("data")
                    .Resolve(SetBatches);
               Field<Boolean>("setCategories")
                    .Argument<POSCategoriesInputType>("data")
                    .Resolve(SetCategories);
               Field<Boolean>("setInventory")
                    .Argument<POSInventoryInputType>("data")
                    .Resolve(SetInventory);
               Field<Boolean>("setMedicationDetails")
                    .Argument<POSMedicationDetailsInputType>("data")
                    .Resolve(SetMedicationDetails);
               Field<Boolean>("setPaymentMethod")
                    .Argument<POSPaymentMethodInputType>("data")
                    .Resolve(SetPaymentMethod);
               Field<Boolean>("setPayments")
                    .Argument<POSPaymentsInputType>("data")
                    .Resolve(SetPayments);
               Field<Boolean>("setProducts")
                    .Argument<POSProductsInputType>("data")
                    .Resolve(SetProducts);
               Field<Boolean>("setProductsTax")
                    .Argument<POSProductsTaxInputType>("data")
                    .Resolve(SetProductsTax);
               Field<Boolean>("setPromotions")
                    .Argument<POSPromotionsInputType>("data")
                    .Resolve(SetPromotions);
               Field<Boolean>("setPromotionsProduct")
                    .Argument<POSPromotionsProductInputType>("data")
                    .Resolve(SetPromotionsProduct);
               Field<Boolean>("setSales")
                    .Argument<POSSalesInputType>("data")
                    .Resolve(SetSales);
               Field<Boolean>("setSaleTaxDetails")
                    .Argument<POSSaleTaxDetailsInputType>("data")
                    .Resolve(SetSaleTaxDetails);
          }
          private bool SetSaleTaxDetails(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               SaleTaxDetails data = new(_System);
               data.Add(context.GetArgument<SaleTaxDetails>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetSales(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Sales data = new(_System);
               data.Add(context.GetArgument<Sales>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPromotionsProduct(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PromotionsProduct data = new(_System);
               data.Add(context.GetArgument<PromotionsProduct>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPromotions(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Promotions data = new(_System);
               data.Add(context.GetArgument<Promotions>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetProductsTax(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               ProductsTax data = new(_System);
               data.Add(context.GetArgument<ProductsTax>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetProducts(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Products data = new(_System);
               data.Add(context.GetArgument<Products>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetPayments(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Payments data = new(_System);
               data.Add(context.GetArgument<Payments>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetPaymentMethod(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               PaymentMethod data = new(_System);
               data.Add(context.GetArgument<PaymentMethod>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetMedicationDetails(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               MedicationDetails data = new(_System);
               data.Add(context.GetArgument<MedicationDetails>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetInventory(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Inventory data = new(_System);
               data.Add(context.GetArgument<Inventory>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetCategories(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Categories data = new(_System);
               data.Add(context.GetArgument<Categories>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetBatches(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Batches data = new(_System);
               data.Add(context.GetArgument<Batches>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetSalesDetails(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               SalesDetails data = new(_System);
               data.Add(context.GetArgument<SalesDetails>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetSimpleReceipts(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               SimpleReceipts data = new(_System);
               data.Add(context.GetArgument<SimpleReceipts>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetTaxes(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Taxes data = new(_System);
               data.Add(context.GetArgument<Taxes>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetRewardsPoints(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               RewardsPoints data = new(_System);
               data.Add(context.GetArgument<RewardsPoints>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetUnitOfMeasure(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               UnitOfMeasure data = new(_System);
               data.Add(context.GetArgument<UnitOfMeasure>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });
     }
}
