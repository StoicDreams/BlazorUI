namespace StoicDreams.BlazorUI.Data;

public interface IAppState
{
	/// <summary>
	/// Set data for the specified data tag.
	/// Note: SetData does not fire event triggers.
	/// Wrap SetData calles in ApplyChanges method or call TriggerChange after last SetData is called.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="tag"></param>
	/// <param name="data"></param>
	void SetData<TData>(AppStateDataTags tag, TData? data);

	/// <summary>
	/// Get data for the specified data tag.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="tag"></param>
	/// <returns></returns>
	TData? GetData<TData>(AppStateDataTags tag);

	/// <summary>
	/// Set data for the specified custom tag name.
	/// Note: SetData does not fire event triggers.
	/// Wrap SetData calles in ApplyChanges method or call TriggerChange after last SetData is called.
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="name"></param>
	/// <param name="data"></param>
	void SetData<TData>(string name, TData? data);

	/// <summary>
	/// Get data for the specified custom tag name
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	/// <param name="name"></param>
	/// <returns></returns>
	TData? GetData<TData>(string name);

	/// <summary>
	/// Subscribe to event trigger called when a state has changed.
	/// When using this make component IDisposable and make sure to call UnsubscribeToDataChanges on Dispose to properly cleanup subscriptions.
	/// Change handler will be passed dictionary with keys representing states that have changed.
	/// Dictionary bool value serves no purpose.
	/// </summary>
	/// <param name="subscriberId"></param>
	/// <param name="changeHandler"></param>
	void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler);

	/// <summary>
	/// Unsubscribe from event trigger.
	/// Typically this is called in Dispose event.
	/// </summary>
	/// <param name="subscriberId"></param>
	void UnsubscribeToDataChanges(Guid subscriberId);

	/// <summary>
	/// Trigger a change event to be called, assuring given key is included in change handler Dictionary.
	/// </summary>
	/// <param name="key"></param>
	void TriggerChange(string key);

	/// <summary>
	/// Use this method to group together multiple state changes and trigger event handlers when finished.
	/// </summary>
	/// <param name="changeHandler"></param>
	/// <returns></returns>
	ValueTask ApplyChangesAsync(Func<ValueTask> changeHandler);

	/// <summary>
	/// Use this method to group together multiple state changes and trigger event handlers when finished.
	/// </summary>
	/// <param name="changeHandler"></param>
	void ApplyChanges(Action changeHandler);
}
