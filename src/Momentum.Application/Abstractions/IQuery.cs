using MediatR;
using Momentum.Domain.Abstractions;


namespace Momentum.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
