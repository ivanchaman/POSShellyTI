using Shelly.ProviderData.Interfaces;

namespace Shelly.GraphQLCore.Services
{
    public class InfoSessionServices : IInfoSessionServices
     {
          private readonly IDbConnectContext _context;
          private readonly ICacheContext _cache;
          private readonly IHttpContextAccessor _httpContextAccessor;
          public InfoSessionServices(IDbConnectContext context, ICacheContext cache, IHttpContextAccessor httpContextAccessor)
          {
               _context = context;
               _cache = cache;
               _httpContextAccessor = httpContextAccessor;
          }

          public LoginInfo? GetInfoSession()
          {
               Validations validation = new Validations(_httpContextAccessor.HttpContext.Request, _context.GetDataAccess(), _cache);
               if (!validation.IsHeaderValid(out LoginInfo? loginInfo, out string error))
                    return null;
               return loginInfo;
          }
     }
}
