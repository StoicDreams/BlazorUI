namespace StoicDreams.BlazorUI.Components.Base;

public abstract class BUICore : ComponentBase, IDisposable
{
	[Inject] protected IAppOptions AppOptions { get; private set; } = null!;
	[Inject] protected ISnackbar Snackbar { get; private set; } = null!;
	[Inject] protected IAppState AppState { get; private set; } = null!;
	[Inject] protected ISessionState SessionState { get; private set; } = null!;
	[Inject] internal IPageState PageState { get; private set; } = null!;

	protected AppOptions HiddenOptions => (AppOptions)AppOptions;

	protected Guid ComponentId { get; } = Guid.NewGuid();

	/// <summary>
	/// Used in a workaround for a rendering issue when updating lists they don't redraw correctly.
	/// </summary>
	protected bool FlipState { get; set; }

	/// <summary>
	/// Get the current page path (excluding any extra query data).
	/// </summary>
	protected string CurrentPage => GetAppState<string>(AppStateDataTags.CurrentPage, () => string.Empty);

	protected override async Task OnInitializedAsync()
	{
		AppStateWatcher.StateChangedHandler = () =>
		{
			OnAppStateUpdate();
			_ = InvokeAsync(StateHasChanged);
		};
		AppStateWatcher.DisposeHandler = () =>
		{
			AppState.UnsubscribeToDataChanges(ComponentId);
		};
		SessionStateWatcher.StateChangedHandler = () => 
		{
			OnSessionStateUpdate();
		};
		SessionStateWatcher.DisposeHandler = () =>
		{
			SessionState.UnsubscribeToDataChanges(ComponentId);
		};
		string currentPage = CurrentPage;
		PageStateWatcher.StateChangedHandler = () =>
		{
			OnPageStateupdate();
		};
		PageStateWatcher.DisposeHandler = () =>
		{
			PageState.UnsubscribeToDataChanges(currentPage, ComponentId);
		};
		AppState.SubscribeToDataChanges(ComponentId, AppStateWatcher.HandleStateChanges);
		SessionState.SubscribeToDataChanges(ComponentId, SessionStateWatcher.HandleStateChanges);
		PageState.SubscribeToDataChanges(currentPage, ComponentId, PageStateWatcher.HandleStateChanges);
		await base.OnInitializedAsync();
	}

	#region App State Helpers
	protected TValue? GetAppState<TValue>(AppStateDataTags key) => AppStateWatcher.WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetAppState<TValue>(string key, Func<TValue> getDefaultValue) => AppStateWatcher.WatchState(key, AppState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
	protected TValue GetAppState<TValue>(AppStateDataTags key, Func<TValue> getDefaultValue) => AppStateWatcher.WatchState(key, AppState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
	protected void SetAppState<TValue>(AppStateDataTags key, TValue? value) => AppState.SetData(key, value);
	protected void SetAppStateWithTrigger<TValue>(AppStateDataTags key, TValue? value)
	{
		AppState.ApplyChanges(() =>
		{
			AppState.SetData(key, value);
		});
	}
	#endregion

	#region Session State Helpers
	protected TValue GetSessionState<TValue>(string key, Func<TValue> getDefaultValue) => SessionStateWatcher.WatchState(key, SessionState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
	protected void SetSessionState<TValue>(string key, TValue? value) => SessionState.SetData(key, value);
	protected void SetSessionStateWithTrigger<TValue>(string key, TValue? value)
	{
		SessionState.ApplyChanges(() =>
		{
			SessionState.SetData(key, value);
		});
	}
	#endregion

	#region Page State Helpers
	protected TValue GetPageState<TValue>(string key, Func<TValue> getDefaultValue) => PageStateWatcher.WatchState(key, PageState.GetData<TValue>(CurrentPage, key) ?? getDefaultValue.Invoke());
	protected void SetPageState<TValue>(string key, TValue? value) => SessionState.SetData(key, value);
	protected void SetPageStateWithTrigger<TValue>(string key, TValue? value)
	{
		string page = CurrentPage;
		PageState.ApplyChanges(page, () =>
		{
			PageState.SetData(page, key, value);
		});
	}
	#endregion

	private StateWatcher AppStateWatcher { get; } = new();
	private StateWatcher SessionStateWatcher { get; } = new();
	private StateWatcher PageStateWatcher { get; } = new();

	protected virtual void OnAppStateUpdate() { }
	protected virtual void OnSessionStateUpdate() { }
	protected virtual void OnPageStateupdate() { }

	public virtual void Dispose()
	{
		AppStateWatcher?.Dispose();
		SessionStateWatcher?.Dispose();
		PageStateWatcher?.Dispose();
	}
}
