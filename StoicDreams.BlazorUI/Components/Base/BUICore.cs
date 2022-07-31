namespace StoicDreams.BlazorUI.Components.Base;

public abstract class BUICore : ComponentBase, IDisposable
{
	[Inject] protected IAppOptions AppOptions { get; private set; } = null!;
	[Inject] protected IAppState AppState { get; private set; } = null!;
	[Inject] protected ISnackbar Snackbar { get; private set; } = null!;

	protected AppOptions HiddenOptions => (AppOptions)AppOptions;

	protected Guid ComponentId { get; } = Guid.NewGuid();

	/// <summary>
	/// Used in a workaround for a rendering issue when updating lists they don't redraw correctly.
	/// </summary>
	protected bool FlipState { get; set; }

	protected override async Task OnInitializedAsync()
	{
		AppState.SubscribeToDataChanges(ComponentId, HandleStateChanges);
		await base.OnInitializedAsync();
	}

	protected TValue? GetState<TValue>(string key) => WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetState<TValue>(string key, Func<TValue> getDefaultValue) => WatchState(key, AppState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
	protected TValue? GetState<TValue>(AppStateDataTags key) => WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetState<TValue>(AppStateDataTags key, Func<TValue> getDefaultValue) => WatchState(key, AppState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
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
		OnStateUpdate();
		_ = InvokeAsync(StateHasChanged);
	}

	protected virtual void OnStateUpdate() { }

	public virtual void Dispose()
	{
		WatchStateKeys.Clear();
		AppState.UnsubscribeToDataChanges(ComponentId);
	}
}
