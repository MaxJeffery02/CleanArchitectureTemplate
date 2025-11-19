using Microsoft.EntityFrameworkCore;
using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;

namespace Momentum.Infrastructure.Users;

internal sealed class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByUserNameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);
    }
}
