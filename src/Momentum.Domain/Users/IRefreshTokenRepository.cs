namespace Momentum.Domain.Users;

public interface IRefreshTokenRepository
{
    void Add(RefreshToken refreshToken);
    Task<IReadOnlyCollection<RefreshToken>> GetByUserAsync(User user, CancellationToken cancellationToken);
}
