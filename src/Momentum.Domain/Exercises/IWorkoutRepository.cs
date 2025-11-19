namespace Momentum.Domain.Exercises;

public interface IWorkoutRepository
{
    void Add(Workout workout);
    void Update(Workout workout);
    void Delete(Workout workout);
    Task<Workout?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
