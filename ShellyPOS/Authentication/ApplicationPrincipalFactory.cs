using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShellyPOS.Models;
using System.Security.Claims;

namespace ShellyPOS.Authentication
{
    public partial class ApplicationPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
      
        public ApplicationPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }
        partial void OnCreatePrincipal(ClaimsPrincipal principal, ApplicationUser user);

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            this.OnCreatePrincipal(principal, user);

            return principal;
        }
    }
}
