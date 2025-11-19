using Momentum.Domain.Users;
using System.Security.Claims;
using Momentum.Application.Users;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Momentum.Infrastructure.Users;

internal sealed class TokenService(IOptions<JwtSettings> options) : ITokenService
{
    private readonly JwtSettings settings = options.Value;

    public string GenerateAccessToken(User user, bool hasMfaCompleted = false)
    {
        var credentials = new SigningCredentials(settings.SigningKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()) };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = settings.Issuer,
            Audience = settings.Audience,
            SigningCredentials = credentials,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(settings.ExpirationInMinutes),
        };

        var tokenHandler = new JsonWebTokenHandler();

        string accessToken = tokenHandler.CreateToken(tokenDescriptor);

        return accessToken;
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}
