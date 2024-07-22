namespace Shelly.POSCore.GraphQL.Query.Dashboard
{
     internal partial class Queries
     {
          public void FieldsPOS()
          {

               Field<PaginationPOSCategoriesType>("getCategories")
                  .Argument<int>("pageNumber")
                  .Argument<int>("rowsOfPage")
                  .Resolve(GetCategories);
               Field<PaginationPOSUnitOfMeasureType>("getUnitOfMeasure")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetUnitOfMeasure);
               Field<PaginationPOSTaxesType>("getTaxes")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetTaxes);
               Field<PaginationPOSBatchesType>("getBatches")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetBatches);
               Field<PaginationPOSInventoryType>("getInventory")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetInventory);
               Field<PaginationPOSMedicationDetailsType>("getMedicationDetails")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetMedicationDetails);
               Field<PaginationPOSPaymentMethodType>("getPaymentMethod")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPaymentMethod);
               Field<PaginationPOSSimpleReceiptsType>("getSimpleReceipts")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetSimpleReceipts);
               Field<PaginationPOSSaleTaxDetailsType>("getSaleTaxDetails")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetSaleTaxDetails);
               Field<PaginationPOSSalesDetailsType>("getSalesDetails")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetSalesDetails);
               Field<PaginationPOSSalesType>("getSales")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetSales);
               Field<PaginationPOSRewardsPointsType>("getRewardsPoints")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetRewardsPoints);
               Field<PaginationPOSPromotionsProductType>("getPromotionsProduct")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPromotionsProduct);
               Field<PaginationPOSPromotionsType>("getPromotions")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPromotions);
               Field<PaginationPOSProductsTaxType>("getProductsTax")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetProductsTax);
               Field<PaginationPOSProductsType>("getProducts")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetProducts);
               Field<PaginationPOSPaymentsType>("getPayments")
                    .Argument<int>("pageNumber")
                    .Argument<int>("rowsOfPage")
                    .Resolve(GetPayments);
         
          }
          private Pagination<Inventory>? GetInventory(IResolveFieldContext context) => context.TryLogged(() => { return new InventoryCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<MedicationDetails>? GetMedicationDetails(IResolveFieldContext context) => context.TryLogged(() => { return new MedicationDetailsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PaymentMethod>? GetPaymentMethod(IResolveFieldContext context) => context.TryLogged(() => { return new PaymentMethodCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Payments>? GetPayments(IResolveFieldContext context) => context.TryLogged(() => { return new PaymentsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Products>? GetProducts(IResolveFieldContext context) => context.TryLogged(() => { return new ProductsCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Categories>? GetCategories(IResolveFieldContext context) => context.TryLogged(() => { return new CategoriesCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Batches>? GetBatches(IResolveFieldContext context) => context.TryLogged(() => { return new BatchesCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<UnitOfMeasure>? GetUnitOfMeasure(IResolveFieldContext context) => context.TryLogged(() => { return new UnitOfMeasureCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Taxes>? GetTaxes(IResolveFieldContext context) => context.TryLogged(() => { return new TaxesCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<SimpleReceipts>? GetSimpleReceipts(IResolveFieldContext context) => context.TryLogged(() => { return new SimpleReceiptsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<SaleTaxDetails>? GetSaleTaxDetails(IResolveFieldContext context) => context.TryLogged(() => { return new SaleTaxDetailsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<SalesDetails>? GetSalesDetails(IResolveFieldContext context) => context.TryLogged(() => { return new SalesDetailsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Sales>? GetSales(IResolveFieldContext context) => context.TryLogged(() => { return new SalesCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<RewardsPoints>? GetRewardsPoints(IResolveFieldContext context) => context.TryLogged(() => { return new RewardsPointsCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<PromotionsProduct>? GetPromotionsProduct(IResolveFieldContext context) => context.TryLogged(() => { return new PromotionsProductCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<Promotions>? GetPromotions(IResolveFieldContext context) => context.TryLogged(() => { return new PromotionsCollection(_System).Where(x => x.Company == _System.Session.Company.Number, context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
          private Pagination<ProductsTax>? GetProductsTax(IResolveFieldContext context) => context.TryLogged(() => { return new ProductsTaxCollection(_System).Where(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("rowsOfPage")); });
     }

}
