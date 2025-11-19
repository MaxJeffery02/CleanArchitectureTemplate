using Momentum.Domain.Users;
using Momentum.Domain.Abstractions;
using Momentum.Application.Abstractions;

namespace Momentum.Application.Users.Login;

internal sealed class LoginCommandHandler(
    IUserRepository userRepository,
    IPasswordService passwordService,
    ITokenService tokenService,
    IRefreshTokenRepository refreshTokenRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByUserNameAsync(command.UserName, cancellationToken);
        if (user is null)
        {
            return Result.Failure<LoginResponse>(UserErrors.InvalidLogin);
        }

        bool isPasswordValid = passwordService.Verify(user, command.Password);
        if (!isPasswordValid)
        {
            return Result.Failure<LoginResponse>(UserErrors.InvalidLogin);
        }

        var refreshTokens = await refreshTokenRepository.GetByUserAsync(user, cancellationToken);
        foreach (RefreshToken token in refreshTokens)
        {
            token.Revoke();
        }

        string accessToken = tokenService.GenerateAccessToken(user);
        string refreshTokenValue = tokenService.GenerateRefreshToken();

        var refreshToken = new RefreshToken(user, refreshTokenValue);

        refreshTokenRepository.Add(refreshToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponse(accessToken, refreshTokenValue);
    }
}
