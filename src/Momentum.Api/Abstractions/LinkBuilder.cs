namespace Momentum.Api.Abstractions;

/// <summary>
/// Link builder for fluent HATEOAS link creation
/// </summary>
public sealed class LinkBuilder
{
    private readonly List<Link> _links = new();
    private readonly string? _baseUrl;

    public LinkBuilder(string? baseUrl = null)
    {
        _baseUrl = baseUrl;
    }

    public LinkBuilder AddSelf(string href)
    {
        _links.Add(new Link(href, "self", "GET"));
        return this;
    }

    public LinkBuilder AddLink(string href, string rel, string method = "GET", string? type = null)
    {
        _links.Add(new Link(href, rel, method, type));
        return this;
    }

    public LinkBuilder AddCreate(string href)
    {
        _links.Add(new Link(href, "create", "POST", "application/json"));
        return this;
    }

    public LinkBuilder AddUpdate(string href)
    {
        _links.Add(new Link(href, "update", "PUT", "application/json"));
        return this;
    }

    public LinkBuilder AddPartialUpdate(string href)
    {
        _links.Add(new Link(href, "partial-update", "PATCH", "application/json"));
        return this;
    }

    public LinkBuilder AddDelete(string href)
    {
        _links.Add(new Link(href, "delete", "DELETE"));
        return this;
    }

    public LinkBuilder AddCollection(string href, string rel = "collection")
    {
        _links.Add(new Link(href, rel, "GET"));
        return this;
    }

    public IReadOnlyCollection<Link> Build() => _links.AsReadOnly();
}
