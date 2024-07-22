using Microsoft.Extensions.Configuration;
using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.Configuration
{
     public class DashBoardSystem : AccountSystem
     {
          public DashBoardSystem(DataAccess dataAccess, ICacheContext cache, IConfiguration section) : base(dataAccess, cache, section)
          {
          }
          public DashBoardSystem(DataAccess dataAccess, ICacheContext cache) : base(dataAccess, cache)
          {              
          }
          public DashBoardSystem(BaseSystem system) : base((DataAccess)system.Connection, system.Cache)
          {              
          }


          protected override void LoadUser(long user)
          {
               User.Load(user);
               if (User.EOF)
                    throw new CoreException(Errors.E00000005);
          }
          protected override void LoadUser(string user)
          {
               User.Load(x => (x.UserName == user || x.Email == user) && x.UserTypeId == 0);
               if (User.EOF)
                    throw new CoreException(Errors.E00000005);
          }
     }
}
