using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Users;

public static class UserErrors
{
    private const string Prefix = "Users";

    public static Error NotFound(Guid id)
    {
        return Error.NotFound($"{Prefix}.{nameof(NotFound)}", $"Could not find user with id '{id}'");
    }

    public static readonly Error InvalidLogin = Error.Failure("User.InvalidUserNameOrPassword", "Username or Password is incorrect");
}
