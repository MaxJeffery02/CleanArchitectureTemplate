using System.Text.Json.Serialization;

namespace Momentum.Api.Abstractions;

/// <summary>
/// Paginated response with HATEOAS support
/// </summary>
public sealed class PagedApiResponse<T>
{
    [JsonPropertyName("data")]
    public IReadOnlyCollection<T> Data { get; init; } = Array.Empty<T>();
    [JsonPropertyName("links")]
    public IReadOnlyCollection<Link> Links { get; init; } = Array.Empty<Link>();
}
