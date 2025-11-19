using Momentum.Application.Exercises.GetExercises;

namespace Momentum.Application.Exercises.GetWorkout;

public sealed class WorkoutResponse 
{
    public Guid Id { get; private set; }
    public string WorkoutName { get; private set; } = string.Empty;
    public HashSet<ExerciseResponse> Exercises { get; private set; } = [];
}