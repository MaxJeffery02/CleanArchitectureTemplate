using Microsoft.AspNetCore.Identity;
using Momentum.Application.Users;
using Momentum.Domain.Users;

namespace Momentum.Infrastructure.Users;

internal sealed class PasswordService(IPasswordHasher<User> passwordHasher) : IPasswordService
{
    public string Hash(string password)
    {
        return passwordHasher.HashPassword(null!, password);
    }

    public bool Verify(User user, string password)
    {
        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result != PasswordVerificationResult.Failed;
    }
}