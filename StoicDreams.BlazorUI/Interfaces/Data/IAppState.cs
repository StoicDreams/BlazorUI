namespace StoicDreams.BlazorUI.Data;

public interface IAppState
{
	void SetData<TData>(string name, TData? data);

	TData? GetData<TData>(string name);

	void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler);

	void UnsubscribeToDataChanges(Guid subscriberId);

	void TriggerChange(string key);

	ValueTask ApplyChanges(Func<ValueTask> changeHandler);
	void ApplyChanges(Action changeHandler);
}
