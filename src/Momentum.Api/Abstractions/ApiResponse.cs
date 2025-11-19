using System.Text.Json.Serialization;

namespace Momentum.Api.Abstractions;

/// <summary>
/// Generic API response wrapper with HATEOAS support
/// </summary>
public sealed record ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; init; }

    [JsonPropertyName("links")]
    public IReadOnlyCollection<Link> Links { get; init; } = Array.Empty<Link>();

    private ApiResponse() { }

    public static ApiResponse<T> Success(T data, params Link[] links)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Links = links,
        };
    }

    public static ApiResponse<T> Success(T data, IEnumerable<Link> links)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Links = links.ToList(),
        };
    }

    public ApiResponse<T> WithLink(string href, string rel, string method = "GET")
    {
        var newLinks = Links.Append(new Link(href, rel, method)).ToList();
        return this with { Links = newLinks };
    }

    public ApiResponse<T> WithLinks(params Link[] additionalLinks)
    {
        var newLinks = Links.Concat(additionalLinks).ToList();
        return this with { Links = newLinks };
    }
}
