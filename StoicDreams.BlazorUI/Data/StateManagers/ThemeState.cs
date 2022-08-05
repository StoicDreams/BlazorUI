namespace StoicDreams.BlazorUI.Data;

public class ThemeState : StateManager, IThemeState
{
	public ThemeState() : base()
	{
		ThemeWatcher = new(HandlerThemeUpdate);
	}

	public ThemeConfig Current
	{
		get
		{
			return CurrentConfig;
		}
		set
		{
			CurrentConfig = value;
			TriggerChange();
		}
	}


	public List<ThemeConfig> Themes => ThemeWatcher;
	private ListWatcher<ThemeConfig> ThemeWatcher { get; }

	private void HandlerThemeUpdate()
	{

	}


	private ThemeConfig CurrentConfig { get; set; } = new();
}
