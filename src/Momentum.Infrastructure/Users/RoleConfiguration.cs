using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ToTable("roles", Schemas.Users);
    }
}
