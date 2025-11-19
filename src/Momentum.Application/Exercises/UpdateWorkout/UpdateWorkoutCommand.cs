using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.UpdateWorkout;

public sealed record UpdateWorkoutCommand(
    Guid UserId, 
    Guid WorkoutId, 
    string WorkoutName,
    IEnumerable<Guid> Exercises) : ICommand;
