using Shelly.GraphQLCore.Interface;
using Shelly.ProviderData.Interfaces;

namespace Shelly.GraphQLCore.Services
{
     public class InfoSessionServices : IInfoSessionServices
     {
          private readonly IDbConnectContext _context;
          private readonly ICacheContext _cache;
          private readonly IHttpContextAccessor _httpContextAccessor;
          private readonly IHeaderValidationServices _headerValidationServices;
          public InfoSessionServices(IDbConnectContext context, ICacheContext cache, IHttpContextAccessor httpContextAccessor, IHeaderValidationServices headerValidationServices)
          {
               _context = context;
               _cache = cache;
               _httpContextAccessor = httpContextAccessor;
               _headerValidationServices = headerValidationServices;
          }

          public LoginInfo? GetInfoSession()
          {               
               if (!_headerValidationServices.IsHeaderValid(out LoginInfo? loginInfo, out string error))
                    return null;
               return loginInfo;
          }
     }
}
