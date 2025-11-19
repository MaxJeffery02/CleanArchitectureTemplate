using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ToTable("role_claims", Schemas.Users);
    }
}
