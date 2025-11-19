namespace Momentum.Application.Abstractions;

public sealed record PagedResult<T>(
    IReadOnlyCollection<T> Items,
    Guid? NextCursor,
    int PageSize,
    bool HasNextPage);
