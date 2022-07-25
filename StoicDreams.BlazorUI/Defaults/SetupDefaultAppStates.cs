namespace StoicDreams.BlazorUI.Defaults;

public static partial class Setup
{
	public static void SetupDefaultAppStates(this IAppState appState)
	{
		appState.SetData(AppStateDataTags.BreadcrumbEnabled, true);
		appState.SetData(AppStateDataTags.DenseTables, true);
		appState.SetData(AppStateDataTags.NavTransitionOutMilliseconds, 300);
		appState.SetData(AppStateDataTags.NavTransitionInMilliseconds, 300);
		appState.SetData(AppStateDataTags.LeftDrawerContent, typeof(BUINavMenu));
		appState.SetData(AppStateDataTags.TitleBarElevation, 5);
		appState.SetData(AppStateDataTags.TitleBarIsDense, true);
		appState.SetData(AppStateDataTags.NavMenuActiveColor, Color.Tertiary);
	}
}
