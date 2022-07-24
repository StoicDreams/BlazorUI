namespace StoicDreams.BlazorUI.Data;

public interface IThemeState
{
	ThemeConfig Current { get; set; }
	List<ThemeConfig> Themes { get; }

	void SubscribeToDataChanges(Guid subscriberId, Action simpleChangeHandler);
	void UnsubscribeToDataChanges(Guid subscriberId);
}
