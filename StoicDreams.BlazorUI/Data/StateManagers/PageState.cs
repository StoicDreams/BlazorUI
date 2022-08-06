namespace StoicDreams.BlazorUI.Data;

public class PageState : IPageState
{
	public PageState(IServiceProvider serviceProvider)
	{
		ServiceProvider = serviceProvider;
	}

	public void SetData<TData>(string page, string name, TData? data)
	{
		IStateManager state = GetState(page);
		state.SetData<TData>(name, data);
	}

	public TData? GetData<TData>(string page, string name)
	{
		IStateManager state = GetState(page);
		return state.GetData<TData>(name);
	}

	public void SubscribeToDataChanges(string page, Guid subscriberId, Action<IDictionary<string, bool>> changeHandler)
	{
		IStateManager state = GetState(page);
		state.SubscribeToDataChanges(subscriberId, changeHandler);
	}

	public void UnsubscribeToDataChanges(string page, Guid subscriberId)
	{
		IStateManager state = GetState(page);
		state.UnsubscribeToDataChanges(subscriberId);
	}

	public void TriggerChange(string page, string? key = null)
	{
		IStateManager state = GetState(page);
		state.TriggerChange(key);
	}

	
	public ValueTask ApplyChangesAsync(string page, Func<ValueTask> changeHandler)
	{
		IStateManager state = GetState(page);
		return state.ApplyChangesAsync(changeHandler);
	}

	public void ApplyChanges(string page, Action changeHandler)
	{
		IStateManager state = GetState(page);
		state.ApplyChanges(changeHandler);
	}

	private IStateManager GetState(string page)
	{
		string key = page.ToLower();
		if (!State.TryGetValue(key, out IStateManager? state))
		{
			state = ServiceProvider.GetRequiredService<IStateManager>();
			State[key] = state;
		}
		return state;
	}

	private Dictionary<string, IStateManager> State { get; set; } = new();
	private IServiceProvider ServiceProvider { get; }
}
