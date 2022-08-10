namespace StoicDreams.BlazorUI.Auth;

public interface IAuthenticate
{
	IUser User { get; set; }
	bool IsLoggedIn { get; }
	bool IsRole(int role);
	bool EmailIsValid(string email, out string message);
	bool PasswordIsValid(string password, out string message);
	ValueTask<TResult> SignIn(string email, string password);
	ValueTask<TResult> SignUp(string email, string displayName);
	ValueTask<TResult> LogOut();
}
