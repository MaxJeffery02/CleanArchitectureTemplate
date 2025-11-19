using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.DeleteWorkout;

public sealed record DeleteWorkoutCommand(Guid WorkoutId, Guid UserId) : ICommand;
