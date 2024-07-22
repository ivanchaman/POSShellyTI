
using Shelly.GraphQLCore.Configuration;
using Shelly.POSCore.GraphQL;

namespace Shelly.POSCore.Services
{
     internal class GraphQLServices : IGraphQLServices
     {
          private readonly IDbConnectContext _dbContext;
          private readonly ICacheContext _dbCache;
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IConfiguration _section;
          public GraphQLServices(IDbConnectContext context, ICacheContext cache, IHttpContextAccessor httpContextAccessor, IConfiguration section)
          {
               _dbContext = context;
               _dbCache = cache;
               _httpContextAccessor = httpContextAccessor;
               _section = section;
          }
          public async Task<GenericResponse> ExecutionResultAccountsSchemaWithoutSession()
          {
               try
               {
                    Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _dbContext.GetDataAccess(), _dbCache);
                    if (!validation.IsHeaderValid(out GraphQLQuery query, out string error, out string additionalMessage))
                         return new GenericResponse(_dbContext.GetDataAccess(), error, additionalMessage);
                    AccountSystem system = new AccountSystem(_dbContext.GetDataAccess(), _dbCache, _section);
                    system.Session.User.Uuid = "0000000000000000000000000000000";
                    using ConnectionHandler manager = new ConnectionHandler(system.Connection);
                    POSAccountsContext schema = new POSAccountsContext(system, false);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }

          public async Task<GenericResponse> ExecutionResultAccountsSchemaWithSession()
          {
               try
               {
                    Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _dbContext.GetDataAccess(), _dbCache);
                    if (!validation.IsHeaderValid(out GraphQLQuery query, out LoginInfo? loginInfo, out string error, out string additionalMessage))
                         return new GenericResponse(_dbContext.GetDataAccess(), error, additionalMessage);
                    AccountSystem system = new AccountSystem(_dbContext.GetDataAccess(), _dbCache, _section);
                    system.LogIn(loginInfo.UserNumber, loginInfo.Company);
                    system.InfoSessionToken = loginInfo;
                    using ConnectionHandler manager = new ConnectionHandler(system.Connection);
                    POSAccountsContext schema = new POSAccountsContext(system, true);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }

          public async Task<GenericResponse> ExecutionResultDashboardSchemaWithoutSession()
          {
               try
               {
                    Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _dbContext.GetDataAccess(), _dbCache);
                    if (!validation.IsHeaderValid(out GraphQLQuery query, out string error, out string additionalMessage))
                         return new GenericResponse(_dbContext.GetDataAccess(), error, additionalMessage);
                    DashBoardSystem system = new DashBoardSystem(_dbContext.GetDataAccess(), _dbCache, _section);
                    system.Session.User.Uuid = "0000000000000000000000000000000";
                    using ConnectionHandler manager = new ConnectionHandler(system.Connection);
                    POSDashboardContext schema = new POSDashboardContext(system, false);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }

          public async  Task<GenericResponse> ExecutionResultDashboardSchemaWithSession()
          {
               try
               {
                    Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _dbContext.GetDataAccess(), _dbCache);
                    if (!validation.IsHeaderValid(out GraphQLQuery query, out LoginInfo? loginInfo, out string error, out string additionalMessage))
                         return new GenericResponse(_dbContext.GetDataAccess(), error, additionalMessage);
                    DashBoardSystem system = new DashBoardSystem(_dbContext.GetDataAccess(), _dbCache, _section);
                    system.LogIn(loginInfo.UserNumber, loginInfo.Company);
                    system.InfoSessionToken = loginInfo;
                    using ConnectionHandler manager = new ConnectionHandler(system.Connection);
                    POSDashboardContext schema = new POSDashboardContext(system, true);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "E00000003", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }
     }
}
