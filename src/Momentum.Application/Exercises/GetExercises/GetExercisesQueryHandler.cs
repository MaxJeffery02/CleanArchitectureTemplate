using Dapper;
using System.Data.Common;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.GetExercises;

internal sealed class GetExercisesQueryHandler(
    IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetExercisesQuery, PagedResult<ExerciseResponse>>
{
    public async Task<Result<PagedResult<ExerciseResponse>>> Handle(
        GetExercisesQuery query,
        CancellationToken cancellationToken)
    {
        const string sql = 
            """
            SELECT 
                id AS Id,
                name AS Name,
                description AS Description
            FROM exercises.exercises
            WHERE (@Cursor IS NULL OR id > @Cursor)
            ORDER BY id ASC
            LIMIT @PageSize + 1
            """;

        await using DbConnection connection = await dbConnectionFactory.OpenAsync(cancellationToken);

        var exercises = (await connection.QueryAsync<ExerciseResponse>(
            sql,
            new
            {
                query.Cursor,
                query.PageSize
            }
        )).AsList();

        var hasNextPage = exercises.Count > query.PageSize;
        if (hasNextPage)
        {
            exercises = exercises.Take(query.PageSize).ToList();
        }

        var nextCursor = hasNextPage ? exercises.LastOrDefault()?.Id : null;

        var pagedResult = new PagedResult<ExerciseResponse>(
            exercises,
            nextCursor,
            query.PageSize,
            hasNextPage);

        return pagedResult;
    }
}