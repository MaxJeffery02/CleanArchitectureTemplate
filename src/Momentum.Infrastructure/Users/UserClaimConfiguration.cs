using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ToTable("user_claims", Schemas.Users);
    }
}
