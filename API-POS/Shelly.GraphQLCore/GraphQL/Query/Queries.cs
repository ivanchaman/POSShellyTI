using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.GraphQL.Query
{
     public partial class Queries : ObjectGraphType
     {
          private BaseSystem _System;
          public Queries(BaseSystem system)
          {
               Name = "BasicQueries";
               _System = system;
               InitFieldsUtilities();
               InitFieldsAuthentication();
          }

          private void InitFieldsUtilities()
          {
               Field<StaticInformationType>("getStaticInformation")
                   .Argument<int>("id")
                   .Argument<double>("version")
                   .Argument<ListGraphType<CatalogVersionInputType>>("data")
                   .Resolve(GetStaticInformation);                                    
          }         

          public void InitFieldsAuthentication()
          {
               Field<LoginType>("getLogin")
                    .Argument<string>("user")
                    .Argument<string>("password")
                    .Argument<int>("company")
                    .Resolve(GetLogin);
          }

          private StaticInformation? GetStaticInformation(IResolveFieldContext context) => context.Try(() =>
          {
               StaticInformation data = new StaticInformation();
               Companies company = new Companies(_System);
               int id = context.GetArgument<int>("id");
               company.Load(id);
               data.Catalogs = GetCatalogs(context.GetArgument<List<CatalogVersion>>("data"));
               return data;
          });
          private LoginInfo? GetLogin(IResolveFieldContext context) => context.Try(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               string token;
               _System.Left = "";               
               if(_System is AccountSystem)
                    ((AccountSystem)_System).LogIn(context.GetArgument<string>("user"), context.GetArgument<string>("password"), context.GetArgument<int>("company"));
               if(_System is DashBoardSystem)     
                    ((DashBoardSystem)_System).LogIn(context.GetArgument<string>("user"), context.GetArgument<string>("password"), context.GetArgument<int>("company"));                                   
               token = TokenGenerator.GenerateTokenJwt(_System.Session.User.Email, _System.Session.User.Uuid);
               LoginInfo newloggin = GetNewLoggin(_System, token);
               if(!_System.HasTwofactor)
                    _System.Cache.AuthStoreData(token, newloggin);
               else
                    _System.Cache.TwoFactorsStoreData(token, newloggin);
               return newloggin;
          });
          public LoginInfo GetNewLoggin(BaseSystem system, string token)
          {
               return new LoginInfo
               {
                    Token = token,
                    UserNumber = system.Session.User.Number,
                    Uuid = system.Session.User.Uuid,
                    Email = system.Session.User.Email,
                    Company = system.Session.Company.Number,
                    HasTwoFactor = system.HasTwofactor,                 
                    PrimaryTwoFactor = system.PrimaryTwoFactor,
                    Left = system.Left,
                    HasTermsStatus = system.HasTermsStatus,
                    TermsServices = system.TermsServices,
                    Status = system.Session.User.Status,
                    HasUserName = String.IsNullOrEmpty(system.Session.User.UserName) || system.Session.User.UserName == system.Session.User.Uuid ? false : true
               };
          }

          private List<CatalogsData>? GetCatalogs(List<CatalogVersion>? data)
          {
               StringBuilder filter = new StringBuilder();
               if (data != null && data.Count > 0)
               {
                    filter.AppendFormat(" id in ({0})", String.Join(',', data.Select(x => x.Id)));
               }
               List<Catalogs> catalogs = new CatalogsCollection(_System).GetCollection(filter.ToString(), false).ToList();
               foreach (var catalog in catalogs)
               {
                    var versions = from data1 in data where data1.Id == catalog.Id select data1.Version;
                    var version = versions.FirstOrDefault();
                    catalog.Data = "";
                    if (catalog.Version != version)
                    {
                         switch (catalog.Id)
                         {
                              case 17:
                                   catalog.Data = new CountriesCollection(_System).GetCollection("", false).Select(x => new Country()
                                   {
                                        Id = x.Id,
                                        Nombre = x.Nombre,
                                        Name = x.Name,
                                        Nom = x.Nom,
                                        Iso2 = x.Iso2,
                                        Iso3 = x.Iso3,
                                        Iso4217 = x.Iso4217,
                                        AbvMoneda = x.AbvMoneda,
                                        PhoneCode = x.PhoneCode,
                                        Status = x.Status,
                                        Emoji = x.Emoji,
                                        Icon = x.Icon,
                                        Capital = x.Capital,
                                        States = x.States,
                                        Region = x.Region
                                   }).ConvertObjectToJson();
                                   break;
                              default:
                                   int id = catalog.Id;
                                   catalog.Data = new CatalogsDetailCollection(_System).GetCollection(x => x.CatalogId == id, 0, 0).Select(x => new Abstractions.Model.CatalogsDetail() { Id = x.Id, Name = x.Name, Description = x.Description }).ConvertObjectToJson();
                                   break;
                         }

                    }
               }
               return catalogs.Select(x => new CatalogsData()
               {
                    Id = x.Id,
                    Data = x.Data,
                    Name = x.Name,
                    Version = x.Version,
                    Description = x.Description
               }).Where(y => !string.IsNullOrEmpty(y.Data)).ToList();
          }
     }
}
