using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Exercises.CreateWorkout;

namespace Momentum.Api.Exercises;

internal sealed class CreateWorkout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("workouts", async (
            [FromBody] CreateWorkoutRequest request,
            ISender sender,
            ClaimsPrincipal principal,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateWorkoutCommand(principal.GetUserId(), request.WorkoutName, request.Exercises);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Handle(workoutId => Results.Created(
                $"/workouts/{workoutId}",
                workoutId.ToApiResponse(links => links
                    .AddCollection("/workouts")
                    .AddSelf($"/workouts/{workoutId}")
                    .AddUpdate($"/workouts/{workoutId}")
                    .AddDelete($"/workouts/{workoutId}")
                    )
                )
            );

        })
        .WithName("CreateWorkout")
        .WithTags(Tags.Exercises)
        .WithSummary("Creates a new workout")
        .WithDescription("Creates a new workout for the currently authenticated user.")
        .Produces<PagedApiResponse<Guid>>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .RequireAuthorization();
    }

    public sealed record CreateWorkoutRequest(string WorkoutName, IEnumerable<Guid> Exercises);
}
