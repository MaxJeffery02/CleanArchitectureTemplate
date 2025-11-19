using Momentum.Domain.Exercises;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.UpdateWorkout;

internal sealed class UpdateWorkoutCommandHandler(
    IWorkoutRepository workoutRepository,
    IExerciseRepository exerciseRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateWorkoutCommand>
{
    public async Task<Result> Handle(UpdateWorkoutCommand command, CancellationToken cancellationToken)
    {
        Workout? workout = await workoutRepository.GetByIdAsync(command.WorkoutId, cancellationToken);

        if (workout is null)
        {
            return Result.Failure(WorkoutErrors.NotFound(command.WorkoutId));
        }

        if (workout.User.Id != command.UserId)
        {
            return Result.Failure(WorkoutErrors.NotOwner(command.WorkoutId, command.UserId));
        }

        IReadOnlyCollection<Exercise> exercises = await exerciseRepository.GetAsync(e => command.Exercises.Contains(e.Id), cancellationToken);

        workout.Update(command.WorkoutName, exercises);

        workoutRepository.Update(workout);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
