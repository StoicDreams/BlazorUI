namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Storage handler for long-term data storage.
/// Implemented by WebStorage for websites.
/// Implemented by AppStorage for modile/desktop apps.
/// </summary>
public interface IStorage
{

	bool Remove(string key);
	object this[string key] { get; set; }
	bool TryGetValue<TValue>(string name, out TValue? value);

	void CopyFrom(IStorage storage);
}
