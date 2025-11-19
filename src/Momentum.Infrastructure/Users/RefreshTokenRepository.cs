using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Momentum.Infrastructure.Users;

internal sealed class RefreshTokenRepository(ApplicationDbContext dbContext) : IRefreshTokenRepository
{
    public void Add(RefreshToken refreshToken)
    {
        dbContext.RefreshTokens.Add(refreshToken);
    }

    public async Task<IReadOnlyCollection<RefreshToken>> GetByUserAsync(User user, CancellationToken cancellationToken)
    {
        return await dbContext.RefreshTokens
            .Where(rt => rt.User.Id == user.Id && rt.RevokedAtUtc == null)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
