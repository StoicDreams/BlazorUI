namespace StoicDreams.BlazorUI.DataTypes;

internal class StateWatcher : IDisposable
{
	public TValue WatchState<TValue>(AppStateDataTags key, TValue value) => WatchState(key.ToString(), value);
	public TValue WatchState<TValue>(string key, TValue value)
	{
		if (!WatchStateKeys.ContainsKey(key))
		{
			WatchStateKeys.Add(key, true);
		}
		return value;
	}

	public Dictionary<string, bool> WatchStateKeys { get; } = new();
	public async ValueTask HandleStateChanges(IDictionary<string, bool> keys)
	{
		if (WatchStateKeys.Keys.Count == 0) { return; }
		if (!WatchStateKeys.Keys.Where(key => keys.ContainsKey(key)).Any()) { return; }
		if (StateChangedHandler != null)
		{
			await StateChangedHandler.Invoke();
		}
	}

	public Func<ValueTask>? StateChangedHandler { get; set; }
	public Action? DisposeHandler { get; set; }

	public void Dispose()
	{
		WatchStateKeys.Clear();
		DisposeHandler?.Invoke();
	}
}
