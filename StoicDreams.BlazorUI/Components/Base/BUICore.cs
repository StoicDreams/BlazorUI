namespace StoicDreams.BlazorUI.Components.Base;

public abstract class BUICore : ComponentBase, IDisposable
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	[Inject] protected IAppOptions AppOptions { get; private set; }
	[Inject] protected IAppState AppState { get; private set; }
	[Inject] protected ISnackbar Snackbar { get; private set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
		_ = InvokeAsync(StateHasChanged);
	}

	public virtual void Dispose()
	{
		WatchStateKeys.Clear();
		AppState.UnsubscribeToDataChanges(ComponentId);
	}
}
