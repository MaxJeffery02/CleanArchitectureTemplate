using Momentum.Domain.Exercises;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Momentum.Infrastructure.Exercises;

internal sealed class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(500);

        builder.HasMany<Workout>()
            .WithMany(w => w.Exercises)
            .UsingEntity<Dictionary<string, object>>(
                "workout_exercises",

                j => j.HasOne<Workout>()
                    .WithMany()
                    .HasForeignKey("workout_id"),

                j => j.HasOne<Exercise>()
                    .WithMany()
                    .HasForeignKey("exercise_id"),

                j =>
                {
                    j.HasKey("workout_id", "exercise_id");
                    j.ToTable("workout_exercises", Schemas.Exercises);
                });

        builder.ToTable("exercises", Schemas.Exercises);
    }
}