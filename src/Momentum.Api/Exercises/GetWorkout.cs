using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Exercises.GetWorkout;

namespace Momentum.Api.Exercises;

internal sealed class GetWorkout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("workouts/{workoutId:guid}", async (
            [FromRoute] Guid workoutId,
            ClaimsPrincipal principal,
            ISender sender,
            CancellationToken cancellationToken = default) =>
        {
            var query = new GetWorkoutQuery(workoutId, principal.GetUserId());

            Result<WorkoutResponse> result = await sender.Send(query, cancellationToken);

            return result.Handle(
                workout => Results.Ok(
                    workout.ToApiResponse(
                        links => links
                            .AddCollection("/workouts")
                            .AddUpdate($"/workouts/{workoutId}")
                            .AddDelete($"/workouts/{workoutId}")
                    )
                )
            );
        })
        .WithName("GetWorkout")
        .WithTags(Tags.Exercises)
        .WithSummary("Get a workout by ID")
        .WithDescription("Retrieves a specific workout with all its exercises for the currently authenticated user.")
        .Produces<ApiResponse<WorkoutResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .RequireAuthorization();
    }
}