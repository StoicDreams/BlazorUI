namespace StoicDreams.BlazorUI.Components.Base;

public abstract class BUICore : ComponentBase, IDisposable
{
	[Inject] public IAppOptions AppOptions { get; private set; } = null!;
	[Inject] public ISnackbar Snackbar { get; private set; } = null!;
	[Inject] public IAppState AppState { get; private set; } = null!;
	[Inject] public ISessionState SessionState { get; private set; } = null!;
	[Inject] internal IPageState PageState { get; private set; } = null!;
	[Inject] public IStorage Storage { get; private set; } = null!;
	[Inject] public NavigationManager NavManager { get; private set; } = null!;
	[Inject] public IClientAuth Auth { get; private set; } = null!;
	[Inject] public IDialogService DialogService { get; private set; } = null!;

	protected AppOptions HiddenOptions => (AppOptions)AppOptions;

	protected Guid ComponentId { get; } = Guid.NewGuid();

	/// <summary>
	/// Get the current page in a relative format (e.g. "/home").
	/// </summary>
	public string CurrentPage => NavManager.ToBaseRelativePath(NavManager.Uri).ToLower();

	/// <summary>
	/// Used in a workaround for a rendering issue when updating lists they don't redraw correctly.
	/// </summary>
	protected bool FlipState { get; set; }

	/// <summary>
	/// Get the current page path (excluding any extra query data).
	/// </summary>
	protected string GetCurrentPage => GetAppState<string>(AppStateDataTags.CurrentPage, () => string.Empty);

	protected void OpenFeedback(string title = "Feedback")
	{
		Type? feedbackComponent = GetAppState<Type>(AppStateDataTags.FeedbackComponent);
		if (feedbackComponent == null)
		{
			Snackbar.Add("Unable to load feedback dialog.", Severity.Error);
			return;
		}
		DialogOptions options = new()
		{
			FullWidth = true
		};
		DialogService.Show(feedbackComponent, title, options);
	}

	public async ValueTask AppStateCallback()
	{
		await OnAppStateUpdate();
		await InvokeAsync(StateHasChanged);
	}

	private async ValueTask SessionStateCallback()
	{
		foreach (Func<ValueTask> handler in SessionStateUpdateHandlers)
		{
			await handler.Invoke();
		}
		await OnSessionStateUpdate();
	}

	private async ValueTask PageStateCallback()
	{
		await OnPageStateupdate();
	}

	protected override async Task OnInitializedAsync()
	{
		AppStateWatcher.StateChangedHandler = AppStateCallback;
		AppStateWatcher.DisposeHandler = () =>
		{
			AppState.UnsubscribeToDataChanges(ComponentId);
		};
		SessionStateWatcher.StateChangedHandler = SessionStateCallback;
		SessionStateWatcher.DisposeHandler = () =>
		{
			SessionState.UnsubscribeToDataChanges(ComponentId);
		};
		string currentPage = GetCurrentPage;
		PageStateWatcher.StateChangedHandler = PageStateCallback;
		PageStateWatcher.DisposeHandler = () =>
		{
			PageState.UnsubscribeToDataChanges(currentPage, ComponentId);
		};
		AppState.SubscribeToDataChanges(ComponentId, AppStateWatcher.HandleStateChanges);
		SessionState.SubscribeToDataChanges(ComponentId, SessionStateWatcher.HandleStateChanges);
		PageState.SubscribeToDataChanges(currentPage, ComponentId, PageStateWatcher.HandleStateChanges);
		await base.OnInitializedAsync();
	}

	#region Auto Session State Helper
	protected async ValueTask<Func<TValue, Task>> SetupSessionKey<TValue>(string sessionKey,
		Action<TValue> valueSetter,
		Func<TValue, Task> onChange,
		Func<TValue> currentGetter,
		Func<TValue> defaultGetter
		)
		where TValue : struct
	{
		bool isUsingSessionStorage = !string.IsNullOrWhiteSpace(sessionKey);
		bool isFirstRun = true;
		async Task ChangeTrigger(TValue value)
		{
			valueSetter.Invoke(value);
			if (!isUsingSessionStorage)
			{
				await changeHandler();
				return;
			}
			TValue cached = await GetSessionState(sessionKey, defaultGetter);
			if (value.ToString() != cached.ToString())
			{
				await SetSessionState(sessionKey, value);
				await onChange.Invoke(value);
			}
		}
		async ValueTask changeHandler()
		{
			if (!isUsingSessionStorage)
			{
				if (isFirstRun)
				{
					isFirstRun = false;
					TValue defaultValue = defaultGetter();
					valueSetter.Invoke(defaultValue);
					await onChange.Invoke(defaultValue);
					return;
				}
				await onChange.Invoke(currentGetter());
				return;
			}
			TValue value = currentGetter();
			TValue cached = await GetSessionState(sessionKey, defaultGetter);
			if (value.ToString() == cached.ToString()) return;
			valueSetter.Invoke(cached);
			await onChange.Invoke(cached);
		}
		if (isUsingSessionStorage)
		{
			SessionStateUpdateHandlers.Add(changeHandler);
		}
		await changeHandler();
		return ChangeTrigger;
	}

	private List<Func<ValueTask>> SessionStateUpdateHandlers { get; } = new();
	#endregion

	#region App State Helpers
	protected TValue? GetAppState<TValue>(AppStateDataTags key) => AppStateWatcher.WatchState(key, AppState.GetData<TValue>(key));
	protected TValue GetAppState<TValue>(AppStateDataTags key, Func<TValue> getDefaultValue) => AppStateWatcher.WatchState(key, AppState.GetData<TValue>(key) ?? getDefaultValue.Invoke());
	protected TValue GetAppState<TValue>(string key, Func<TValue> getDefaultValue) => AppStateWatcher.WatchState(key, AppState.GetDataAsync<TValue>(key).GetAwaiter().GetResult() ?? getDefaultValue.Invoke());
	protected void SetAppState<TValue>(AppStateDataTags key, TValue? value) => AppState.SetData(key, value);
	protected void SetAppStateWithTrigger<TValue>(AppStateDataTags key, TValue? value)
	{
		AppState.SetData(key, value);
		_ = AppState.TriggerChangeAsync(key.AsName());
	}
	#endregion

	#region Session State Helpers
	protected async ValueTask<TValue> GetSessionState<TValue>(string key, Func<TValue> getDefaultValue) => SessionStateWatcher.WatchState(key, await SessionState.GetDataAsync<TValue>(key) ?? getDefaultValue.Invoke());
	protected ValueTask SetSessionState<TValue>(string key, TValue? value) => SessionState.SetDataAsync(key, value);
	protected ValueTask SetSessionStateWithTrigger<TValue>(string key, TValue? value)
	{
		return SessionState.ApplyChangesAsync(async () =>
		{
			await SessionState.SetDataAsync(key, value);
		});
	}
	protected async ValueTask LoadStateFromSession<TValue>(AppStateDataTags tag)
	{
		TResult<TValue> session = await SessionState.TryGetState<TValue>(tag.AsName());
		if (session.IsOkay)
		{
			await AppState.SetDataAsync(tag.AsName(), session.Result);
		}
	}
	protected void SetAppSessionWithTrigger<TValue>(AppStateDataTags tag, TValue value)
	{
		_ = SessionState.SetDataAsync(tag.AsName(), value);
		SetAppStateWithTrigger(tag, value);
	}
	protected void SetAppSession<TValue>(AppStateDataTags tag, TValue value)
	{
		_ = SessionState.SetDataAsync(tag.AsName(), value);
		SetAppState(tag, value);
	}
	#endregion

	#region Page State Helpers
	protected async ValueTask<TValue> GetPageState<TValue>(string key, Func<TValue> getDefaultValue) => PageStateWatcher.WatchState(key, await PageState.GetData<TValue>(GetCurrentPage, key) ?? getDefaultValue.Invoke());
	protected ValueTask SetPageState<TValue>(string key, TValue? value) => SessionState.SetDataAsync(key, value);
	protected async ValueTask SetPageStateWithTrigger<TValue>(string key, TValue? value)
	{
		string page = GetCurrentPage;
		await PageState.ApplyChangesAsync(page, async () =>
		{
			await PageState.SetData(page, key, value);
		});
	}
	#endregion

	private StateWatcher AppStateWatcher { get; } = new();
	private StateWatcher SessionStateWatcher { get; } = new();
	private StateWatcher PageStateWatcher { get; } = new();

	protected virtual ValueTask OnAppStateUpdate() => ValueTask.CompletedTask;
	protected virtual ValueTask OnSessionStateUpdate() => ValueTask.CompletedTask;
	protected virtual ValueTask OnPageStateupdate() => ValueTask.CompletedTask;

	#region Helper Methods
	protected string FirstNotEmpty(params string?[] options)
	{
		foreach (string? option in options)
		{
			if (string.IsNullOrWhiteSpace(option)) { continue; }
			return option;
		}
		return string.Empty;
	}
	#endregion

	public virtual void Dispose()
	{
		SessionStateUpdateHandlers.Clear();
		AppStateWatcher?.Dispose();
		SessionStateWatcher?.Dispose();
		PageStateWatcher?.Dispose();
	}
}
