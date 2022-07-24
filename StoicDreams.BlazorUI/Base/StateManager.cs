namespace StoicDreams.BlazorUI.Base;

public abstract class StateManager
{
	public void SubscribeToDataChanges(Guid subscriberId, Action simpleChangeHandler)
	{
		SimpleChangeHandlers[subscriberId] = simpleChangeHandler;
	}

	public void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
	{
		ChangeHandlers[subscriberId] = changeHandler;
	}

	public void UnsubscribeToDataChanges(Guid subscriberId)
	{
		ChangeHandlers.Remove(subscriberId);
		SimpleChangeHandlers.Remove(subscriberId);
	}

	public void SetData<TData>(AppStateDataTags tag, TData? data) => SetData(tag.ToString(), data);
	
	public TData? GetData<TData>(AppStateDataTags tag) => GetData<TData>(tag.ToString());

	public void SetData<TData>(string name, TData? data)
	{
		UpdatedKey(name);
		if (data == null)
		{
			Data.Remove(name);
			return;
		}
		Data[name] = data;
	}

	public TData? GetData<TData>(string name)
	{
		if (!Data.TryGetValue(name, out object? value) || value == null)
		{
			return default;
		}
		try
		{
			return (TData)value;
		}
		catch
		{
			return default;
		}
	}

	public void TriggerChange(string? key = null)
	{
		if (key != null) { Changelog[key] = true; }		
		foreach (Guid id in ChangeHandlers.Keys)
		{
			ChangeHandlers[id]?.Invoke(Changelog);
		}
		foreach (Guid id in SimpleChangeHandlers.Keys)
		{
			SimpleChangeHandlers[id]?.Invoke();
		}
	}
	public async ValueTask ApplyChangesAsync(Func<ValueTask> changeHandler)
	{
		await changeHandler.Invoke();
		TriggerChange("ApplyChanges");
		Changelog.Clear();
	}

	public void ApplyChanges(Action changeHandler)
	{
		changeHandler.Invoke();
		TriggerChange("ApplyChanges");
		Changelog.Clear();
	}
	private void UpdatedKey(string key)
	{
		Changelog[key] = true;
	}

	protected Dictionary<string, object> Data { get; } = new();
	protected Dictionary<string, bool> Changelog { get; } = new();
	protected Dictionary<Guid, Action<IDictionary<string, bool>>> ChangeHandlers { get; } = new();
	protected Dictionary<Guid, Action> SimpleChangeHandlers { get; } = new();
}
