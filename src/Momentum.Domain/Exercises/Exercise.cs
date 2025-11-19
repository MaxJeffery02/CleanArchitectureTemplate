namespace Momentum.Domain.Exercises;

public sealed class Exercise
{
    private Exercise()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Exercise(string name, string description)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        Description = description;
    }
}
