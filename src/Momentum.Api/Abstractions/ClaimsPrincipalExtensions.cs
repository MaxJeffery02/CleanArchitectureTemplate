using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Momentum.Api.Abstractions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        Claim? claim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier) 
            ?? throw new InvalidOperationException("UserId is unavailable");

        return Guid.TryParse(claim.Value, out Guid userId) 
            ? userId 
            : throw new InvalidOperationException("UserId is unavailable");
    }
}
