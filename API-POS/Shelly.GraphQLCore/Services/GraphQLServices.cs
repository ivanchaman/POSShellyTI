using Microsoft.Extensions.Configuration;
using Shelly.GraphQLCore.Interface;
using Shelly.ProviderData.Interfaces;

namespace Shelly.GraphQLCore.Services
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
                    AccountsContext schema = new AccountsContext(system, false);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
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
                    AccountsContext schema = new AccountsContext(system, true);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
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
                    DashboardContext schema = new DashboardContext(system, false);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }
          public async Task<GenericResponse> ExecutionResultDashboardSchemaWithSession()
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
                    DashboardContext schema = new DashboardContext(system, true);
                    return await schema.ExecutionResult(query);
               }
               catch (Exception ex)
               {
                    return new GenericResponse() { Result = false, Errors = new[] { new Shelly.GraphQLCore.Model.ErrorSystem() { Id = "", Type = -1, DefaultMessage = ex.Message, Stack = ex.ToString() } } };
               }
          }
         
     }
}
