using Momentum.Domain.Users;

namespace Momentum.Domain.Exercises;

public sealed class Workout
{
    private readonly List<Exercise> _exercises = [];

    private Workout()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public User User { get; private set; }
    public IReadOnlyCollection<Exercise> Exercises => _exercises.ToList();

    public Workout(string name, User user, IReadOnlyCollection<Exercise> exercises)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        User = user;
        _exercises.AddRange(exercises);
    }

    public void Update(string name, IReadOnlyCollection<Exercise> exercises)
    {
        Name = name;

        foreach (var exercise in exercises)
        {
            if (!_exercises.Any(e => e.Id == exercise.Id))
            {
                _exercises.Add(exercise);
            }
        }
    }
}
