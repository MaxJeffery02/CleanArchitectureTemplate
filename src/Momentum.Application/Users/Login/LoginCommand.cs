using Momentum.Application.Abstractions;

namespace Momentum.Application.Users.Login;

public sealed record LoginCommand(string UserName, string Password) : ICommand<LoginResponse>;