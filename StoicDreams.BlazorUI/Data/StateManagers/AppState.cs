namespace StoicDreams.BlazorUI.Data;

public class AppState : StateManager, IAppState
{
	public AppState(IMemoryStorage memory, IAppOptions options) : base(memory)
	{
		_ = ApplyStartupOptionsToState(options);
	}

	public ValueTask SetDataAsync<TData>(AppStateDataTags tag, TData? data) => SetDataAsync(tag.ToString(), data);

	public ValueTask<TData?> GetDataAsync<TData>(AppStateDataTags tag) => GetDataAsync<TData>(tag.ToString());

	public void SetData<TData>(AppStateDataTags tag, TData? data)
	{
		ValueTask task = SetDataAsync(tag.ToString(), data);
		task.AndForget(TaskOption.None);
	}

	public TData? GetData<TData>(AppStateDataTags tag)
	{
		return GetDataAsync<TData>(tag).GetAwaiter().GetResult();
	}

	public new void ApplyChanges(Action changeHandler)
	{
		base.ApplyChanges(changeHandler);
	}

	private async ValueTask ApplyStartupOptionsToState(IAppOptions options)
	{
		await SetDataAsync(AppStateDataTags.AppLeftDrawerVariant.ToString(), options.LeftDrawerVariant);
		await SetDataAsync(AppStateDataTags.AppRightDrawerVariant.ToString(), options.RightDrawerVariant);
	}
}
