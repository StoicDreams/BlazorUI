namespace StoicDreams.BlazorUI.Defaults;

public static partial class Setup
{
	public static void SetupDefaultThemes(this IAppState appState)
	{
		appState.SetData(AppStateDataTags.Themes, new List<ThemeConfig>()
		{
			new()
			{
				Name = "Dark Mode",
				AppBarBackground = "#451b8eff",
				AppBackground = "#1d1c1dff",
				DrawerBackground = "#1d1c1dff",
				Black = "#101010ff",
				Warning = "#ff5500ff",
			},
			new()
			{
				Name = "Light Mode",
				AppBarBackground = "#5118b4ff",
				AppBackground = "#ebe6daff",
				DrawerBackground = "#ebe6daff",
				Black = "#282828ff",
			}
		});
	}
}
