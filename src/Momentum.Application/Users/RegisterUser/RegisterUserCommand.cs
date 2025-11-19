using Momentum.Application.Abstractions;

namespace Momentum.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string UserName, 
    string FirstName, 
    string LastName, 
    string Email, 
    DateTime DateOfBirth,
    string Password) : ICommand<Guid>;