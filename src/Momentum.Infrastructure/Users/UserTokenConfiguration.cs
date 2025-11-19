using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        builder.ToTable("user_tokens", Schemas.Users);
    }
}