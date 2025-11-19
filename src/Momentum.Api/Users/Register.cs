using MediatR;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Users.RegisterUser;

namespace Momentum.Api.Users;

internal sealed class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users", async (
            RegisterUserCommand command,
            ISender sender,
            CancellationToken cancellation) =>
        {
            Result<Guid> result = await sender.Send(command, cancellation);

            return result.Handle(userId => Results.Created(
                $"/users/{userId}",
                userId.ToApiResponse(links => links
                    .AddCollection("/users")
                    .AddSelf($"/users/{userId}")
                    .AddUpdate($"/users/{userId}")
                    .AddDelete($"/users/{userId}")
                    )
                )
            );
        })
        .WithName("RegisterUser")
        .WithTags(Tags.Users)
        .WithDescription("Creates a new user account with the provided credentials and profile information.")
        .WithSummary("egister a new user")
        .Produces<ApiResponse<Guid>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .AllowAnonymous();
    }
}
