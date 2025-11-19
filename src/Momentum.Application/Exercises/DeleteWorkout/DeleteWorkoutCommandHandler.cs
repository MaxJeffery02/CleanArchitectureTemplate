using Momentum.Domain.Exercises;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.DeleteWorkout;

internal sealed class DeleteWorkoutCommandHandler(
    IWorkoutRepository workoutRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<DeleteWorkoutCommand>
{
    public async Task<Result> Handle(DeleteWorkoutCommand command, CancellationToken cancellationToken)
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

        workoutRepository.Delete(workout);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
