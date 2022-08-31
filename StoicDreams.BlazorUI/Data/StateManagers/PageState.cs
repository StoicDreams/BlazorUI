namespace StoicDreams.BlazorUI.Data;

public class PageState : IPageState
{
	public PageState(IServiceProvider serviceProvider)
	{
		ServiceProvider = serviceProvider;
	}

	public async ValueTask SetData<TData>(string page, string name, TData? data)
	{
		IStateManager state = GetState(page);
		await state.SetDataAsync<TData>(name, data);
	}

	public async ValueTask<TData?> GetData<TData>(string page, string name)
	{
		IStateManager state = GetState(page);
		return await state.GetDataAsync<TData>(name);
	}

	public void SubscribeToDataChanges(string page, Guid subscriberId, Func<IDictionary<string, bool>, ValueTask> changeHandler)
	{
		IStateManager state = GetState(page);
		state.SubscribeToDataChanges(subscriberId, changeHandler);
	}

	public void UnsubscribeToDataChanges(string page, Guid subscriberId)
	{
		IStateManager state = GetState(page);
		state.UnsubscribeToDataChanges(subscriberId);
	}

	public async ValueTask TriggerChange(string page, string? key = null)
	{
		IStateManager state = GetState(page);
		await state.TriggerChangeAsync(key);
	}

	
	public async ValueTask ApplyChangesAsync(string page, Func<ValueTask> changeHandler)
	{
		IStateManager state = GetState(page);
		await state.ApplyChangesAsync(changeHandler);
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
