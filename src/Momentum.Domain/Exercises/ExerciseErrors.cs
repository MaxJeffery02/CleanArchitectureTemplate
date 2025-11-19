using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Exercises;

public static class ExerciseErrors
{
    private const string Prefix = "Exercise";

    public static Error NotFound(Guid id)
    {
        return Error.NotFound($"{Prefix}.{nameof(NotFound)}", $"Could not find exercise with id '{id}'");
    }
}
