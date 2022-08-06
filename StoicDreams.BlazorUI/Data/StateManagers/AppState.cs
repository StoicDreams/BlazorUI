namespace StoicDreams.BlazorUI.Data;

public class AppState : StateManager, IAppState
{
	public AppState(IMemoryStorage memory, IAppOptions options) : base(memory)
	{
		ApplyStartupOptionsToState(options);
	}

	private void ApplyStartupOptionsToState(IAppOptions options)
	{
		SetData(AppStateDataTags.AppLeftDrawerVariant.ToString(), options.LeftDrawerVariant);
		SetData(AppStateDataTags.AppRightDrawerVariant.ToString(), options.RightDrawerVariant);
	}
	public void SetData<TData>(AppStateDataTags tag, TData? data) => SetData(tag.ToString(), data);

	public TData? GetData<TData>(AppStateDataTags tag) => GetData<TData>(tag.ToString());
}
