using Momentum.Domain.Users;

namespace Momentum.Application.Users;

public interface ITokenService
{
    string GenerateAccessToken(User user, bool hasMfaCompleted = false);
    string GenerateRefreshToken();
}
