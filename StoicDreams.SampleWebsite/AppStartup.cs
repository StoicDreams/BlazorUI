namespace StoicDreams.SampleWebsite;

public class AppStartup : BUICore
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	[Inject] private IThemeState ThemeState { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	protected override Task OnInitializedAsync()
	{
		SetupWebSiteSpecificThemes();
		return base.OnInitializedAsync();
	}

	private void SetupWebSiteSpecificThemes()
	{
		// Clear out the default themes from the framework
		ThemeState.Themes.Clear();

		// Set your new themes here
		ThemeState.Themes.AddRange(new List<ThemeConfig>()
		{
			new()
			{
				Name = "Dark Mode",
				AppBarBackground = "#57007Fff",
				AppBackground = "#1d1c1dff",
				DrawerBackground = "#1d1c1dff",
				Black = "#101010ff",
				Warning = "#ff5500ff",
				Secondary = "#bf0f49ff"
			},
			new()
			{
				Name = "Light Mode",
				AppBarBackground = "#57007Fff",
				AppBackground = "#ebe6daff",
				DrawerBackground = "#ebe6daff",
				Black = "#282828ff",
				Warning = "#e86202ff",
				Secondary = "#bf0f49ff"
			}
		}); ;

		// Make sure to set your default theme as current
		ThemeState.Current = ThemeState.Themes[0];
	}
}
