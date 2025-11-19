using Momentum.Domain.Users;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IPasswordService passwordService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        string hashedPassword = passwordService.Hash(request.Password);

        var user = new User(
            request.UserName,
            request.FirstName,
            request.LastName,
            request.Email,
            hashedPassword,
            request.DateOfBirth);

        userRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
