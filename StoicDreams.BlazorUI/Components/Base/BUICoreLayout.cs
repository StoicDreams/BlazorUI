namespace StoicDreams.BlazorUI.Components.Base;

public abstract class BUICoreLayout : LayoutComponentBase, IDisposable
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	[Inject] protected IAppOptions AppOptions { get; private set; }
	[Inject] protected IAppState AppState { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	protected AppOptions HiddenOptions => (AppOptions)AppOptions;

	protected Guid ComponentId { get; } = Guid.NewGuid();

	protected override async Task OnInitializedAsync()
	{
		AppState.SubscribeToDataChanges(ComponentId, HandleStateChanges);
		await base.OnInitializedAsync();
	}

	protected TValue? GetState<TValue>(string key) => WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetState<TValue>(string key, TValue defaultValue) => WatchState(key, AppState.GetData<TValue>(key) ?? defaultValue);
	protected TValue? GetState<TValue>(AppStateDataTags key) => WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetState<TValue>(AppStateDataTags key, TValue defaultValue) => WatchState(key, AppState.GetData<TValue>(key) ?? defaultValue);
	protected void SetState<TValue>(AppStateDataTags key, TValue? value) => AppState.SetData(key, value);
	protected void SetStateWithTrigger<TValue>(AppStateDataTags key, TValue? value)
	{
		AppState.ApplyChanges(() =>
		{
			AppState.SetData(key, value);
		});
	}

	private TValue WatchState<TValue>(AppStateDataTags key, TValue value) => WatchState(key.ToString(), value);
	private TValue WatchState<TValue>(string key, TValue value)
	{
		if (!WatchStateKeys.ContainsKey(key))
		{
			WatchStateKeys.Add(key, true);
		}
		return value;
	}

	private Dictionary<string, bool> WatchStateKeys { get; } = new();
	private void HandleStateChanges(IDictionary<string, bool> keys)
	{
		if (WatchStateKeys.Keys.Count == 0) { return; }
		if (!WatchStateKeys.Keys.Where(key => keys.ContainsKey(key)).Any()) { return; }
		InvokeAsync(StateHasChanged);
	}

	public void Dispose()
	{
		WatchStateKeys.Clear();
		AppState.UnsubscribeToDataChanges(ComponentId);
	}
}
