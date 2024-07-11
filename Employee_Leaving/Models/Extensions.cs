﻿using System.Security.Claims;
using System.Security.Principal;

namespace Employee_Leaving.Models
{
    public static class Extensions
    {
        public static string GetClaimRole(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Role);
            return claim.Value;
        }
        public static string GetClaimName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim Name = claimsIdentity.FindFirst(ClaimTypes.Name);
            return Name.Value;

        }
        public static string GetClaimValue(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim Id = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return Id.Value;
        }
    }
}
