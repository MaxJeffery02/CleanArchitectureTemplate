using System.Linq.Expressions;

namespace Momentum.Domain.Exercises;

public interface IExerciseRepository
{
    Task<IReadOnlyCollection<Exercise>> GetAsync(Expression<Func<Exercise, bool>> predicate, CancellationToken cancellationToken = default);
}
