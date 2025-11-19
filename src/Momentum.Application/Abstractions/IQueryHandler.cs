using MediatR;
using Momentum.Domain.Abstractions;

namespace Momentum.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
