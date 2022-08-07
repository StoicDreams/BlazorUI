namespace StoicDreams.BlazorUI.Auth;

public class Authenticate : IAuthenticate
{
	public IUser User { get; set; } = new User();
	public bool IsLoggedIn => User.Role > 0;
	public bool IsRole(int role)
	{
		if (role == User.Role) { return true; }
		if ((role & User.Role) != 0) { return true; }
		return false;
	}
}
