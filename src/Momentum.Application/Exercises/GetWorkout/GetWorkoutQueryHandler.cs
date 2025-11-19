using Dapper;
using System.Data.Common;
using Momentum.Domain.Exercises;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;
using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Application.Exercises.GetWorkout;

internal sealed class GetWorkoutQueryHandler(
    IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetWorkoutQuery, WorkoutResponse>
{
    public async Task<Result<WorkoutResponse>> Handle(GetWorkoutQuery query, CancellationToken cancellationToken)
    {
        const string sql =
            """
            SELECT
                w.id AS Id,
                w.name AS WorkoutName,
                e.id AS Id,
                e.name AS Name,
                e.description AS Description
            FROM exercises.workouts w
            LEFT JOIN exercises.workout_exercises we ON w.id = we.workout_id
            LEFT JOIN exercises.exercises e ON we.exercise_id = e.id
            WHERE w.id = @WorkoutId
            AND w.user_id = @UserId
            """;

        await using DbConnection connection = await dbConnectionFactory.OpenAsync(cancellationToken);

        var workoutDictionary = new Dictionary<Guid, WorkoutResponse>();

        await connection.QueryAsync<WorkoutResponse, ExerciseResponse?, WorkoutResponse>(
            sql,
            (workout, exercise) =>
            {
                if (!workoutDictionary.TryGetValue(workout.Id, out var workoutEntry))
                {
                    workoutEntry = workout;
                    workoutDictionary.Add(workout.Id, workoutEntry);
                }

                if (exercise is not null)
                {
                    workoutEntry.Exercises.Add(exercise);
                }

                return workoutEntry;
            },
            query,
            splitOn: "Id");

        WorkoutResponse? workout = workoutDictionary.Values.FirstOrDefault();

        if (workout is null)
        {
            return Result.Failure<WorkoutResponse>(WorkoutErrors.NotFound(query.WorkoutId));
        }

        return workout;
    }
}