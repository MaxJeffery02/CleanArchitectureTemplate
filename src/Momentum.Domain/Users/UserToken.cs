using Microsoft.AspNetCore.Identity;

namespace Momentum.Domain.Users;

public sealed class UserToken : IdentityUserToken<Guid>;
