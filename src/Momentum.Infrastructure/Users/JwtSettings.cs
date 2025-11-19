using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Momentum.Infrastructure.Users;

internal sealed class JwtSettings
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public int ExpirationInMinutes { get; init; }

    public TokenValidationParameters ValidationParameters => new()
    {
        ValidateIssuer = true,
        ValidIssuer = Issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SigningKey,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    public SymmetricSecurityKey SigningKey => new(Encoding.UTF8.GetBytes(SecretKey));
}
