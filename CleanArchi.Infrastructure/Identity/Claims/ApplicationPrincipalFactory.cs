using CleanArchi.Infrastructure.Identity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Infrastructure.Identity.Claims
{
    public class ApplicationPrincipalFactory : IUserClaimsPrincipalFactory<ApplicationUser>
    {
        public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
              Claim[] claims = new Claim[] {
              new Claim(ClaimTypes.Email, user.Email ?? ""),
              new Claim(ClaimTypes.Name, user.Email??""),
              new Claim(ClaimTypes.NameIdentifier, user.Id), 
              new Claim("IsTwoFactorEnabled", user.TwoFactorEnabled.ToString() ?? ""),
              new Claim("IsEmailConfirmed", user.EmailConfirmed.ToString() ?? ""),
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return Task.FromResult(claimsPrincipal);
        }
    }
}
