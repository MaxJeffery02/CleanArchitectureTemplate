namespace Momentum.Domain.Users;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetByUserNameAsync(string username, CancellationToken cancellationToken = default);
}
