using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Exercises.UpdateWorkout;

namespace Momentum.Api.Exercises;

internal sealed class UpdateWorkout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("workouts/{workoutId:guid}", async (
            [FromRoute] Guid workoutId,
            [FromBody] UpdateWorkoutRequest request,
            ClaimsPrincipal principal,
            ISender sender,
            CancellationToken cancellationToken = default) =>
        {
            var command = new UpdateWorkoutCommand(
                principal.GetUserId(),
                workoutId,
                request.WorkoutName,
                request.Exercises);

            Result result = await sender.Send(command, cancellationToken);

            return result.Handle(() => Results.Ok(
                workoutId.ToApiResponse(links => links
                    .AddCollection("/workouts")
                    .AddSelf($"/workouts/{workoutId}")
                    .AddDelete($"/workouts/{workoutId}")
                )
            ));
        })
        .WithName("UpdateWorkout")
        .WithTags(Tags.Exercises)
        .WithSummary("Updates a workout")
        .WithDescription("Updates a specified workout by its unique identifier for the currently authenticated user. This will replace the workout's name and list of exercises.")
        .Produces<ApiResponse<Guid>>(StatusCodes.Status200OK) 
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .RequireAuthorization();
    }

    public sealed record UpdateWorkoutRequest(string WorkoutName, IEnumerable<Guid> Exercises);
}