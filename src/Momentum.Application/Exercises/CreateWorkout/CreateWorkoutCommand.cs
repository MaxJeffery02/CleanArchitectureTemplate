using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.CreateWorkout;

public sealed record CreateWorkoutCommand(
    Guid UserId, 
    string WorkoutName, 
    IEnumerable<Guid> Exercises) : ICommand<Guid>;
