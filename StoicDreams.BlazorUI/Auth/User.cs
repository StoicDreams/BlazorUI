namespace StoicDreams.BlazorUI.Auth;

public class User : IUser
{
	public Guid SessionId { get; set; }
	public string Name { get; set; } = "Guest";
	public int Role { get; set; }
}
