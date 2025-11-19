using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.GetExercises;

public sealed record GetExercisesQuery(Guid? Cursor, int PageSize) : IQuery<PagedResult<ExerciseResponse>>;