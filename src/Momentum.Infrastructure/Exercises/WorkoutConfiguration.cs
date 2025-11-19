using Momentum.Domain.Exercises;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Exercises;

internal sealed class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasOne(w => w.User)
            .WithMany()
            .HasForeignKey("user_id")
            .IsRequired();

        builder.ToTable("workouts", Schemas.Exercises);
    }
}
