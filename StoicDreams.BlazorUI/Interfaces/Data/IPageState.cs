namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Data storage mapped to specific pages.
/// Store data within this container that is shared within components within a given page, but do not carry over to other pages.
/// </summary>
internal interface IPageState
{
	/// <summary>
	/// Set page data
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="page"></param>
	/// <param name="name"></param>
	/// <param name="data"></param>
	ValueTask SetData<TData>(string page, string name, TData? data);

	/// <summary>
	/// Get page data
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="page"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	ValueTask<TData?> GetData<TData>(string page, string name);

	/// <summary>
	/// Subscribe to page data changes
	/// </summary>
	/// <param name="page"></param>
	/// <param name="subscriberId"></param>
	/// <param name="changeHandler"></param>
	void SubscribeToDataChanges(string page, Guid subscriberId, Func<IDictionary<string, bool>, ValueTask> changeHandler);

	/// <summary>
	/// Unsubscribe from page data changes
	/// </summary>
	/// <param name="page"></param>
	/// <param name="subscriberId"></param>
	void UnsubscribeToDataChanges(string page, Guid subscriberId);

	ValueTask TriggerChange(string page, string? key = null);

	ValueTask ApplyChangesAsync(string page, Func<ValueTask> changeHandler);
}
