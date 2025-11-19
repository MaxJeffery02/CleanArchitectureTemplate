using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.GetWorkout;

public sealed record GetWorkoutQuery(Guid WorkoutId, Guid UserId) : IQuery<WorkoutResponse>;