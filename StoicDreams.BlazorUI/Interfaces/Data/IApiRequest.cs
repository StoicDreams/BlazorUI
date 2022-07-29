namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Abstraction and simplification for usage of HttpClient as well as providing a mockable interface to use in place of.
/// </summary>
public interface IApiRequest
{
	ValueTask<TResult<T>> Get<T>(string url, bool isCacheable);
}
