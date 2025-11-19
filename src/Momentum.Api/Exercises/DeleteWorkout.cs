using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Exercises.DeleteWorkout;

namespace Momentum.Api.Exercises;

internal sealed class DeleteWorkout : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("workouts/{workoutId:guid}", async (
            [FromRoute] Guid workoutId,
            ClaimsPrincipal principal,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteWorkoutCommand(workoutId, principal.GetUserId());

            Result result = await sender.Send(command, cancellationToken);

            return result.Handle(() => Results.NoContent());
        })
        .WithName("DeleteWorkout")
        .WithTags(Tags.Exercises)
        .WithSummary("Deletes a workout")
        .WithDescription("Deletes a specified workout by its unique identifier for the currently authenticated user.")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .RequireAuthorization();
    }
}