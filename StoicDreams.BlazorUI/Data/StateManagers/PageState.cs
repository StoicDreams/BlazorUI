namespace StoicDreams.BlazorUI.Data;

public class PageState : IPageState
{
	public void SetData<TData>(string page, string name, TData? data)
	{
		StateManager state = GetState(page);
		state.SetData<TData>(name, data);
	}

	public TData? GetData<TData>(string page, string name)
	{
		StateManager state = GetState(page);
		return state.GetData<TData>(name);
	}

	public void SubscribeToDataChanges(string page, Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
	{
		StateManager state = GetState(page);
		state.SubscribeToDataChanges(subscriberId, changeHandler);
	}

	public void UnsubscribeToDataChanges(string page, Guid subscriberId)
	{
		StateManager state = GetState(page);
		state.UnsubscribeToDataChanges(subscriberId);
	}

	public void TriggerChange(string page, string? key = null)
	{
		StateManager state = GetState(page);
		state.TriggerChange(key);
	}

	
	public ValueTask ApplyChangesAsync(string page, Func<ValueTask> changeHandler)
	{
		StateManager state = GetState(page);
		return state.ApplyChangesAsync(changeHandler);
	}

	public void ApplyChanges(string page, Action changeHandler)
	{
		StateManager state = GetState(page);
		state.ApplyChanges(changeHandler);
	}

	private StateManager GetState(string page)
	{
		string key = page.ToLower();
		if (!State.TryGetValue(key, out StateManager? state))
		{
			state = new();
			State[key] = state;
		}
		return state;
	}

	private Dictionary<string, StateManager> State { get; set; } = new();
}
