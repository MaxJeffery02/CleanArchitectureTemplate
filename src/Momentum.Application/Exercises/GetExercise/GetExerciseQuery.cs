using Momentum.Application.Abstractions;
using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Application.Exercises.GetExercise;

public sealed record GetExerciseQuery(Guid ExerciseId) : IQuery<ExerciseResponse>;
