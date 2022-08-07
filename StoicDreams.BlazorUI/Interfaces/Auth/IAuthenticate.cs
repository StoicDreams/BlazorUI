namespace StoicDreams.BlazorUI.Auth;

public interface IAuthenticate
{
	IUser User { get; set; }
	bool IsLoggedIn { get; }
	bool IsRole(int role);
}
