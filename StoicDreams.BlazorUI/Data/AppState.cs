namespace StoicDreams.BlazorUI.Data;

public class AppState : StateManager, IAppState
{
	public AppState(IAppOptions options) : base()
	{
		ApplyStartupOptionsToState(options);
	}

	private void ApplyStartupOptionsToState(IAppOptions options)
	{
		SetData(AppStateDataTags.AppLeftDrawerVariant.ToString(), options.LeftDrawerVariant);
		SetData(AppStateDataTags.AppRightDrawerVariant.ToString(), options.RightDrawerVariant);
	}
}
