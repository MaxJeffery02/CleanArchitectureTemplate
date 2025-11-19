using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Momentum.Api.Abstractions;

internal static class EndpointExtensions
{
    internal static IServiceCollection AddEndpoints(
        this IServiceCollection services, 
        Assembly presentationAssembly)
    {
        IEnumerable<ServiceDescriptor> serviceDescriptors = presentationAssembly
            .GetTypes()
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    internal static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}
