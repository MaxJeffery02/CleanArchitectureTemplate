using Momentum.Application.Abstractions;

namespace Momentum.Api.Abstractions;

public static class PagedResultExtensions
{
    public static PagedApiResponse<T> ToPagedApiResponse<T>(
        this PagedResult<T> pagedResult,
        string baseUrl,
        Guid? requestCursor,
        Action<LinkBuilder>? configureAdditionalLinks = null)
    {
        var links = new List<Link>();

        // Self link with current cursor
        var selfUrl = requestCursor.HasValue
            ? $"{baseUrl}?cursor={requestCursor}&pageSize={pagedResult.PageSize}"
            : $"{baseUrl}?pageSize={pagedResult.PageSize}";

        links.Add(new Link(selfUrl, "self", "GET"));

        links.Add(new Link($"{baseUrl}?pageSize={pagedResult.PageSize}", "first", "GET"));

        if (pagedResult.HasNextPage && pagedResult.NextCursor.HasValue)
        {
            links.Add(new Link(
                $"{baseUrl}?cursor={pagedResult.NextCursor}&pageSize={pagedResult.PageSize}",
                "next",
                "GET"
            ));
        }

        // Add additional links if provided
        if (configureAdditionalLinks != null)
        {
            var builder = new LinkBuilder();
            configureAdditionalLinks(builder);
            links.AddRange(builder.Build());
        }

        return new PagedApiResponse<T>
        {
            Links = links,
            Data = pagedResult.Items,
        };
    }
}