namespace StoicDreams.BlazorUI.Base;

public abstract class StateManager : IStateManager
{
	public void SubscribeToDataChanges(Guid subscriberId, Action simpleChangeHandler)
	{
		lock (ChangeHandlerLock)
		{
			SimpleChangeHandlers[subscriberId] = simpleChangeHandler;
		}
	}

	public void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
	{
		lock (ChangeHandlerLock)
		{
			ChangeHandlers[subscriberId] = changeHandler;
		}
	}

	public void UnsubscribeToDataChanges(Guid subscriberId)
	{
		lock (ChangeHandlerLock)
		{
			ChangeHandlers.Remove(subscriberId);
			SimpleChangeHandlers.Remove(subscriberId);
		}
	}

	public void SetData<TData>(AppStateDataTags tag, TData? data) => SetData(tag.ToString(), data);
	
	public TData? GetData<TData>(AppStateDataTags tag) => GetData<TData>(tag.ToString());

	public void SetData<TData>(string name, TData? data)
	{
		UpdatedKey(name);
		lock (DataLock)
		{
			if (data == null)
			{
				Data.Remove(name);
				return;
			}
			Data[name] = data;
		}
	}

	public TData? GetData<TData>(string name)
	{
		lock (DataLock)
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
	}

	public void TriggerChange(string? key = null)
	{
		Dictionary<string, bool> currentState;
		lock (ChangeLogLock)
		{
			if (key != null) { Changelog[key] = true; }
			currentState = Changelog.ToDictionary(k => k.Key, v => v.Value);
		}
		Action<IDictionary<string, bool>>[] handlers;
		Action[] simpleHandlers;
		lock (ChangeHandlerLock)
		{
			handlers = ChangeHandlers.Values.ToArray();
			simpleHandlers = SimpleChangeHandlers.Values.ToArray();
		}
		foreach (Action<IDictionary<string, bool>> handler in handlers)
		{
			handler?.Invoke(currentState);
		}
		foreach (Action handler in simpleHandlers)
		{
			handler?.Invoke();
		}
	}
	public async ValueTask ApplyChangesAsync(Func<ValueTask> changeHandler)
	{
		await changeHandler.Invoke();
		TriggerChange("ApplyChanges");
		lock (ChangeLogLock)
		{
			Changelog.Clear();
		}
	}

	public void ApplyChanges(Action changeHandler)
	{
		changeHandler.Invoke();
		TriggerChange("ApplyChanges");
		lock (ChangeLogLock)
		{
			Changelog.Clear();
		}
	}
	private void UpdatedKey(string key)
	{
		lock(ChangeLogLock)
		{
			Changelog[key] = true;
		}
	}

	protected Dictionary<string, object> Data { get; } = new();
	protected Dictionary<string, bool> Changelog { get; } = new();
	protected Dictionary<Guid, Action<IDictionary<string, bool>>> ChangeHandlers { get; } = new();
	protected Dictionary<Guid, Action> SimpleChangeHandlers { get; } = new();

	private readonly object DataLock = new();
	private readonly object ChangeLogLock = new();
	private readonly object ChangeHandlerLock = new();
}
