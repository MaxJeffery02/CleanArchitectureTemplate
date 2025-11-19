namespace Momentum.Application.Exercises.GetExercises;

public sealed record ExerciseResponse(
    Guid Id,
    string Name,
    string Description);
