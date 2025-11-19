using MediatR;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Users.Login;

namespace Momentum.Api.Users;

internal sealed class Login : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("login", async (
            LoginCommand command,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            Result<LoginResponse> result = await sender.Send(command, cancellationToken);

            return result.Handle(response => Results.Ok(
                response.ToApiResponse(links => links
                    .AddSelf("/login")
                    .AddLink("/logout", "logout", "POST")
                    .AddLink("/refresh-token", "refresh", "POST")
                    .AddLink("/users/me", "current-user", "GET")
                    .AddLink("/users/me", "update-profile", "PUT")
                    .AddLink("/users/me/change-password", "change-password", "POST")
                    )
                )
            );
        })
        .WithName("Login")
        .WithTags(Tags.Users)
        .WithSummary("Authenticate user")
        .WithDescription("Authenticates a user and returns an access token with HATEOAS links for available actions.")
        .Produces<ApiResponse<LoginResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .AllowAnonymous();
    }
}