using System.Linq.Expressions;
using Momentum.Domain.Exercises;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Momentum.Infrastructure.Exercises;

internal sealed class ExerciseRepository(ApplicationDbContext dbContext) : IExerciseRepository
{
    public async Task<IReadOnlyCollection<Exercise>> GetAsync(
        Expression<Func<Exercise, bool>> predicate, 
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Exercises
            .Where(predicate)
            .ToListAsync(cancellationToken); 
    }
}
