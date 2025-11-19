using Momentum.Domain.Users;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Users;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(rt => rt.Id);  

        builder.HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey("user_id")
            .IsRequired();

        builder.ToTable("refresh_tokens", Schemas.Users);
    }
}