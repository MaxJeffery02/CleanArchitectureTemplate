using Microsoft.Extensions.Configuration;

namespace Momentum.Infrastructure.Abstractions;

public static class ConfigurationExtensions
{
    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name)
    {
        return configuration.GetConnectionString(name) ??
            throw new InvalidOperationException($"The connection string {name} was not found");
    }

    public static T GetOrThrow<T>(this IConfiguration configuration, string name)
    {
        return configuration.GetValue<T?>(name) ??
            throw new InvalidOperationException($"The connection string {name} was not found");
    }

    public static T GetSectiontOrThrow<T>(this IConfiguration configuration, string section)
    {
        return configuration.GetSection(section).Get<T>() ??
            throw new InvalidOperationException($"{nameof(T)} was not found");
    }
}
