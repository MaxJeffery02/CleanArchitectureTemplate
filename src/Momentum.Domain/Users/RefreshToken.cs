namespace Momentum.Domain.Users;

public sealed class RefreshToken
{
    private RefreshToken()
    {
    }

    public Guid Id { get; private set; }
    public User User { get; private set; }
    public string Value { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime ExpiresAtUtc { get; private set; }
    public DateTime? RevokedAtUtc { get; private set; }

    const int ExpirationInDays = 7;

    public RefreshToken(User user, string value)
    {
        User = user;
        Value = value;
        CreatedAtUtc = DateTime.UtcNow;
        ExpiresAtUtc = DateTime.UtcNow.AddDays(ExpirationInDays);
    }

    public void Revoke()
    {
        if (RevokedAtUtc.HasValue)
        {
            return;
        }

        RevokedAtUtc = DateTime.UtcNow;
    }
}
