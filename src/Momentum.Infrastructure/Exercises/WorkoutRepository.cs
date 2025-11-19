using Momentum.Domain.Exercises;
using Momentum.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Momentum.Infrastructure.Exercises;

internal sealed class WorkoutRepository(ApplicationDbContext dbContext) : IWorkoutRepository
{
    public void Add(Workout workout)
    {
        foreach (Exercise exercise in workout.Exercises)
        {
            dbContext.Attach(exercise);
        }

        dbContext.Workouts.Add(workout);
    }

    public void Update(Workout workout)
    {
        foreach (Exercise exercise in workout.Exercises)
        {
            dbContext.Attach(exercise);
        }

        dbContext.Workouts.Update(workout);
    }

    public void Delete(Workout workout)
    {
        dbContext.Workouts.Remove(workout);
    }

    public async Task<Workout?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Workouts
            .Include(w => w.User)
            .Include(w => w.Exercises)
            .SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
    }

}
