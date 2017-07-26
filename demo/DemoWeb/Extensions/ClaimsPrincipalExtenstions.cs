using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoWeb.Extensions
{
    public static class ClaimsPrincipalExtenstions
    {
        public static string FindClaim(this ClaimsPrincipal user, string claimType)
        {
            var result = String.Empty;

            if(user != null)
            {
                var claim = user.Claims.SingleOrDefault(c => c.Type == claimType);
                if(claim != null)
                {
                    result = claim.Value;
                }
            }

            return result;
        }
    }
}
