using System;
using System.Security.Claims;
using EnglishTrainer.API.Authentication;

namespace EnglishTrainer.API.Extensions
{
    public static class UserExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(JwtClaimTypes.Id));
        }
    }
}
