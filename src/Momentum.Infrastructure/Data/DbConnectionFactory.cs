using Npgsql;
using System.Data.Common;
using Momentum.Application.Abstractions;

namespace Momentum.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenAsync(CancellationToken cancellationToken = default)
    {
        return await dataSource.OpenConnectionAsync(cancellationToken);
    }
}
