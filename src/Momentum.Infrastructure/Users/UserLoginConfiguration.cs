using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

        builder.HasIndex(ul => ul.UserId);

        builder.ToTable("user_logins", Schemas.Users);
    }
}
