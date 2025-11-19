using Momentum.Domain.Users;
using Momentum.Domain.Exercises;
using Microsoft.EntityFrameworkCore;
using Momentum.Application.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Momentum.Infrastructure.Data;

internal sealed class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal DbSet<Exercise> Exercises { get; private set; }
    internal DbSet<Workout> Workouts { get; private set; }
    internal DbSet<RefreshToken> RefreshTokens { get; private set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
