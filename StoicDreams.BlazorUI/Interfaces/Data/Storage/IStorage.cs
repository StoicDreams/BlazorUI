namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Storage handler for long-term data storage.
/// Implemented by WebStorage for websites.
/// Implemented by AppStorage for modile/desktop apps.
/// </summary>
public interface IStorage : IDisposable
{
	IEnumerable<string> Keys { get; }

	ValueTask<bool> Remove(string key);
	ValueTask SetValue(string key, object value);
	ValueTask<TValue?> GetValue<TValue>(string name);

	ValueTask CopyFrom(IStorage storage);
}
