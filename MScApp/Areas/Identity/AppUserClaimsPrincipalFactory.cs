using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MScApp.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MScApp.Areas.Identity
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {

        public AppUserClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Admin",
                user.IsAdmin.ToString()));
            identity.AddClaim(new Claim("FirstName",
                user.FirstName));
            identity.AddClaim(new Claim("FullName",
                user.FirstName + user.LastName));
            return identity;
        }
    }
}
