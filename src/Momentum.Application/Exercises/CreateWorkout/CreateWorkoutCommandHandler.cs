using Momentum.Domain.Users;
using Momentum.Domain.Exercises;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Exercises.CreateWorkout;

internal sealed class CreateWorkoutCommandHandler(
    IUserRepository userRepository,
    IExerciseRepository exerciseRepository,
    IWorkoutRepository workoutRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateWorkoutCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateWorkoutCommand command, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(command.UserId));
        }

        IReadOnlyCollection<Exercise> exercises = await exerciseRepository.GetAsync(e => command.Exercises.Contains(e.Id), cancellationToken);

        var workout = new Workout(command.WorkoutName, user, exercises);

        workoutRepository.Add(workout);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return workout.Id;
    }
}
