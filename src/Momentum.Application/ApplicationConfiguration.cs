using Microsoft.Extensions.DependencyInjection;

namespace Momentum.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        return services;
    }
}
