using Momentum.Application;
using Momentum.Infrastructure;
using Momentum.Api.Abstractions;
using Momentum.Infrastructure.Abstractions;

namespace Momentum.Api;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddExceptionHandler<ProblemDetailsHandler>();
        builder.Services.AddProblemDetails();

        string databaseConnectionString = builder.Configuration.GetConnectionStringOrThrow("Database");

        builder.Services.AddEndpoints(AssemblyReference.Assembly);

        builder.Services.AddInfrastructure(
            builder.Configuration, 
            databaseConnectionString);

        builder.Services.AddApplication();

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.ApplyMigrations();
        }

        app.UseHttpsRedirection();

        app.MapEndpoints();

        app.UseExceptionHandler();

        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();
    }
}