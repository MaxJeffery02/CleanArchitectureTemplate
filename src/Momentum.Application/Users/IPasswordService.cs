using Momentum.Domain.Users;

namespace Momentum.Application.Users;

public interface IPasswordService
{
    string Hash(string password);
    bool Verify(User user, string password);
}
