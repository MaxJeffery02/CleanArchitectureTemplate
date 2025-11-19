using System.Data.Common;

namespace Momentum.Application.Abstractions;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenAsync(CancellationToken cancellationToken = default);
}
