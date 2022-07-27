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
