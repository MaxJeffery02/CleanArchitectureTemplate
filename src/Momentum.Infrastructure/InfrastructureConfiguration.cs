using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Momentum.Application.Abstractions;
using Momentum.Application.Users;
using Momentum.Domain.Exercises;
using Momentum.Domain.Users;
using Momentum.Infrastructure.Abstractions;
using Momentum.Infrastructure.Data;
using Momentum.Infrastructure.Exercises;
using Momentum.Infrastructure.Users;
using Npgsql;

namespace Momentum.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration,
        string databaseConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(databaseConnectionString).UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddIdentity(configuration);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordService, PasswordService>();

        return services;
    }

    private static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 12;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders(); 

        services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var settings = configuration.GetSectiontOrThrow<JwtSettings>("Jwt");
            options.TokenValidationParameters = settings.ValidationParameters;
        });

        services.AddAuthorization();

        return services;
    }
}
