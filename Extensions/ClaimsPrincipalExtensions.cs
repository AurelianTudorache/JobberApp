using System;
using System.Security.Claims;

namespace JobberApp.Extensions
{
    public static class ClaimsPrincipalExtensionsasda
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}