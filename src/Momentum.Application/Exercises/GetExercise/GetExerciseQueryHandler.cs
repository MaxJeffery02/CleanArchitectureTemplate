using Dapper;
using System.Data.Common;
using Momentum.Domain.Exercises;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;
using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Application.Exercises.GetExercise;

internal sealed class GetExerciseQueryHandler(
    IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetExerciseQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT 
                id AS Id,
                name AS Name,
                description AS Description
            FROM exercises.exercises
            WHERE id = @ExerciseId
            """;

        await using DbConnection connection = await dbConnectionFactory.OpenAsync(cancellationToken);

        ExerciseResponse? exercise = await connection.QuerySingleOrDefaultAsync<ExerciseResponse>(sql, query);

        if (exercise is null)
        {
            return Result.Failure<ExerciseResponse>(ExerciseErrors.NotFound(query.ExerciseId));
        }

        return exercise;
    }
}
