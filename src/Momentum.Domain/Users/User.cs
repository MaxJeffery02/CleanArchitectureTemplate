using Microsoft.AspNetCore.Identity;

namespace Momentum.Domain.Users;

public sealed class User : IdentityUser<Guid>
{
    private User()
    {
    }

    public new Guid Id { get; private set; }
    public new string UserName { get; private set; }
    public new string Email { get; private set; }
    public new string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirthUtc { get; private set; }

    public User(
        string username, 
        string firstname, 
        string lastname, 
        string email,
        string passwordHash,
        DateTime dob)
    {
        Id = Guid.CreateVersion7();
        UserName = username;
        Email = email;
        FirstName = firstname;
        LastName = lastname;
        PasswordHash = passwordHash;
        DateOfBirthUtc = dob.Kind == DateTimeKind.Utc
            ? dob
            : DateTime.SpecifyKind(dob, DateTimeKind.Utc);
    }
}
