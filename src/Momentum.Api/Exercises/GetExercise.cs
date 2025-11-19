using MediatR;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Exercises.GetExercise;
using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Api.Exercises;

internal sealed class GetExercise : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("exercises/{exerciseId:guid}", async (
            [FromRoute] Guid exerciseId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetExerciseQuery(exerciseId);

            Result<ExerciseResponse> result = await sender.Send(query, cancellationToken);

            return result.Handle(exercise => Results.Ok(
                exercise.ToApiResponse(links => links
                    .AddCollection("/exercises")
                    .AddSelf($"/exercise/{exercise.Id}")
                )
            ));

        })
        .WithName("GetExercise")
        .WithTags(Tags.Exercises)
        .WithSummary("Get exercise by its unique identifier")
        .WithDescription("Retrieves a single exercise by its unique GUID. Returns a 404 Not Found if the exercise does not exist.")
        .Produces<ApiResponse<ExerciseResponse>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .AllowAnonymous();
    }
}