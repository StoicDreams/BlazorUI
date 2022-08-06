namespace StoicDreams.BlazorUI.Data;

public class ThemeState : StateManager, IThemeState
{
	public ThemeState(IMemoryStorage memory) : base(memory)
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
			TriggerChangeAsync();
		}
	}


	public List<ThemeConfig> Themes => ThemeWatcher;
	private ListWatcher<ThemeConfig> ThemeWatcher { get; }

	private void HandlerThemeUpdate()
	{

	}


	private ThemeConfig CurrentConfig { get; set; } = new();
}
