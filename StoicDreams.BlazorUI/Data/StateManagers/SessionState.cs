namespace StoicDreams.BlazorUI.Data;

public class SessionState : StateManager, ISessionState
{
	public SessionState(
		IStorage storage
		) : base(storage)
	{
	}
}
