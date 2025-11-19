using System.Text.Json.Serialization;

namespace Momentum.Api.Abstractions;

/// <summary>
/// HATEOAS link representation
/// </summary>
public sealed record Link(
    [property: JsonPropertyName("href")] string Href,
    [property: JsonPropertyName("rel")] string Rel,
    [property: JsonPropertyName("method")] string Method = "GET",
    [property: JsonPropertyName("type")] string? Type = null
);
