using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Exercises;

public static class WorkoutErrors
{
    private const string Prefix = "Workout";

    public static Error NotFound(Guid id)
    {
        return Error.NotFound($"{Prefix}.{nameof(NotFound)}", $"Could not find workout with id '{id}'");
    }

    public static Error NotOwner(Guid workoutId, Guid userId)
    {
        return Error.Problem($"{Prefix}.{nameof(NotOwner)}", $"Workout with id '{workoutId}' does not belong to user with id '{userId}'");
    }
}
