namespace StoicDreams.BlazorUI.Data;

public class ThemeState : IThemeState
{
	public ThemeConfig Current { get; set; } = new();
	public List<ThemeConfig> Themes { get; } = new();

	public void ListenForChanges(Guid callerId, Action handler)
	{
		ChangeHandlers[callerId] = handler;
	}

	public void TriggerChange()
	{
		foreach (Guid key in ChangeHandlers.Keys)
		{
			ChangeHandlers[key].Invoke();
		}
	}

	private Dictionary<Guid, Action> ChangeHandlers { get; } = new();
}
