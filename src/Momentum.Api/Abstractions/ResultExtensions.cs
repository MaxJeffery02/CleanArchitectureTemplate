using Momentum.Domain.Abstractions;

namespace Momentum.Api.Abstractions;

/// <summary>
/// Extension methods for Result with HATEOAS support
/// </summary>
public static class ResultExtensions
{
    public static IResult Handle(
        this Result result,
        Func<IResult> onSuccess,
        Func<Result, IResult>? onFailure = null)
    {
        return result.IsSuccess ? onSuccess() : onFailure is null ? ApiResults.Problem(result) : onFailure(result);
    }

    public static IResult Handle<TData>(
        this Result<TData> result,
        Func<TData, IResult> onSuccess,
        Func<Result<TData>, IResult>? onFailure = null)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure is null ? ApiResults.Problem(result) : onFailure(result);
    }

    public static ApiResponse<T> ToApiResponse<T>(this T data, Action<LinkBuilder> configureLinks)
    {
        var builder = new LinkBuilder();
        configureLinks(builder);
        return ApiResponse<T>.Success(data, builder.Build());
    }
}