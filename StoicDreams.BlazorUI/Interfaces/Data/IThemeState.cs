namespace StoicDreams.BlazorUI.Data;

public interface IThemeState
{
	ThemeConfig Current { get; set; }
	List<ThemeConfig> Themes { get; }
}
