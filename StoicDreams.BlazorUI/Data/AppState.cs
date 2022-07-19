namespace StoicDreams.BlazorUI.Data;

public class AppState : IAppState
{
	public AppState(IJsInterop jsInterop, IAppOptions options)
	{
		Interop = jsInterop;
		ApplyStartupOptionsToState(options);
		LoadSimpleDataFromStorage();
	}

	private void ApplyStartupOptionsToState(IAppOptions options)
	{
		SetData(AppStateDataTags.AppLeftDrawerVariant.ToString(), options.LeftDrawerVariant);
		SetData(AppStateDataTags.AppRightDrawerVariant.ToString(), options.RightDrawerVariant);
	}

	public void SetData<TData>(AppStateDataTags tag, TData? data) => SetData(tag.ToString(), data);
	public TData? GetData<TData>(AppStateDataTags tag) => GetData<TData>(tag.ToString());

	public void SetData<TData>(string name, TData? data)
	{
		SaveSimpleDataToStorage(name, data);
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

	public void SubscribeToDataChanges(Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
	{
		ChangeHandlers[subscriberId] = changeHandler;
	}

	public void UnsubscribeToDataChanges(Guid subscriberId)
	{
		ChangeHandlers.Remove(subscriberId);
	}

	public void TriggerChange(string key)
	{
		Changelog[key] = true;
		foreach (Guid id in ChangeHandlers.Keys)
		{
			TriggerHandler(ChangeHandlers[id]);
		}
	}

	private void TriggerHandler(Action<IDictionary<string, bool>> handler)
	{
		handler.Invoke(Changelog);
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

	private void SaveSimpleDataToStorage<TData>(string name, TData data)
	{
		UpdatedKey(name);
		// TODO
	}

	private void LoadSimpleDataFromStorage()
	{
		// TODO
	}

	private Dictionary<Guid, Action<IDictionary<string, bool>>> ChangeHandlers { get; } = new();
	private Dictionary<string, object> Data { get; } = new();
	private Dictionary<string, bool> Changelog { get; } = new();
	private IJsInterop Interop { get; }
}
