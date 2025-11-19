using MediatR;
using Microsoft.AspNetCore.Mvc;
using Momentum.Api.Abstractions;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;
using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Api.Exercises;

internal sealed class GetExercises : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("exercises", async (
            [FromQuery] Guid? cursor,
            [FromQuery] int? pageSize,
            [FromQuery] string? sortBy,
            [FromQuery] bool? ascending,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new GetExercisesQuery(cursor, pageSize ?? 20);

            Result<PagedResult<ExerciseResponse>> result = await sender.Send(query, cancellationToken);

            return result.Handle(
                pagedResult => Results.Ok(
                    pagedResult.ToPagedApiResponse(
                        "/exercises",
                        cursor,
                        links => links.AddCreate("/exercises")
                    ))
            );
        })
        .WithName("GetExercises")
        .WithTags(Tags.Exercises)
        .WithSummary("Get exercises with keyset pagination")
        .WithDescription("Retrieves a paginated list of exercises using cursor-based pagination for efficient large dataset traversal.")
        .Produces<PagedApiResponse<ExerciseResponse>>(StatusCodes.Status200OK)
        .AllowAnonymous();
    }
}
