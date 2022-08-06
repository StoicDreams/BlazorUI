namespace StoicDreams.BlazorUI.Data;

public class SessionState : StateManager, ISessionState
{
	public SessionState(
		IMemoryStorage memory,
		IStorage storage
		) : base(memory)
	{
		Storage = storage;
	}

	private IStorage Storage { get; }
}
