namespace StoicDreams.BlazorUI.Defaults;

public static partial class Setup
{
	public static void SetupDefaultAppStates(this IAppState appState)
	{
		appState.SetData(AppStateDataTags.NavTransitionOutMilliseconds, 300);
		appState.SetData(AppStateDataTags.NavTransitionInMilliseconds, 300);
		appState.SetData(AppStateDataTags.LeftDrawerContent, typeof(BUINavMenu));
		appState.SetData(AppStateDataTags.TitleBarElevation, 5);
	}
}
