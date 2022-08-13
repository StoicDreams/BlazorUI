using System.Text.RegularExpressions;

namespace StoicDreams.BlazorUI.Auth;

/// <summary>
/// Placeholder class for IAuthenticate to allow simulating signup/login during initial development.
/// Websites are expected to create their own IAuthenticate instance to override this instance.
/// </summary>
public class MockAuthenticate : IClientAuth
{
	public MockAuthenticate(
		ISessionState sessionState,
		IAppState appState
		)
	{
		SessionState = sessionState;
		AppState = appState;
	}

	public async ValueTask CheckLoginFromCache()
	{
		string? data = await SessionState.GetDataAsync<string>("auth");
		if (data == null) { return; }
		User user = data.ConvertFromWebEncryptedString<User>();
		if (user.SessionId == Guid.Empty) { return; }
		await SetupForLoggedInUser(user);
	}

	public IUser User { get; set; } = new User();
	public bool IsLoggedIn => User.Role > 0;
	public bool IsRole(int role)
	{
		if (role == 0) { return true; }
		if (role == User.Role) { return true; }
		if ((role & User.Role) != 0) { return true; }
		return false;
	}
	public bool EmailIsValid(string email, out string message)
	{
		if (string.IsNullOrWhiteSpace(email))
		{
			message = "Email is required.";
			return false;
		}
		if (!ValidEmailPattern.IsMatch(email))
		{
			message = "We do not recognize your email as a valid email address";
			return false;
		}
		message = "Email validated successfully.";
		return true;
	}
	private static Regex ValidEmailPattern = new(@"^[A-Za-z0-9-_]{1,}(\.[A-Za-z0-9-_]{1,})*\@[A-Za-z0-9-_]{1,}(\.[A-Za-z0-9]{1,})+$", RegexOptions.Compiled | RegexOptions.Singleline);

	public bool PasswordIsValid(string password, out string message)
	{
		if (string.IsNullOrWhiteSpace(password))
		{
			message = "Password is required";
			return false;
		}
		if (password.Length < MinimumPasswordLength)
		{
			message = $"Passwords must be at least {MinimumPasswordLength} characters in length";
			return false;
		}
		message = "Password meets minimum requirements";
		return true;
	}
	private const short MinimumPasswordLength = 10;

	public async ValueTask<TResult> SignIn(string email, string password)
	{
		User user = new User()
		{
			SessionId = User.SessionId == Guid.Empty ? Guid.NewGuid() : User.SessionId,
			Name = await SessionState.GetDataAsync<string>(email) ?? "User",
			Role = 1
		};
		await SessionState.SetDataAsync("auth", user.ConvertToWebEncryptedString());
		await SetupForLoggedInUser(user);
		return await ValueTask.FromResult(TResult.Success($"Welcome {User.Name}! Mock Sign-in succeeded."));
	}

	private async ValueTask SetupForLoggedInUser(User user)
	{
		User = user;
		AppState.SetData(AppStateDataTags.TitleBarRightDrawerIcon, DrawerIconWhenLoggedIn);
		AppState.SetData(AppStateDataTags.TitleBarRightDrawerTitle, "Toggle Right Drawer");
		await AppState.TriggerChangeAsync(AppStateDataTags.UserAuthUpdate);
	}

	private string DrawerIconWhenLoggedIn { get; } = Icons.Material.TwoTone.AccountCircle;
	private string DrawerIconWhenLoggedOut { get; } = Icons.Material.TwoTone.Login;

	public ValueTask<TResult> SignUp(string email, string displayName)
	{
		SessionState.SetDataAsync(email, displayName);
		return ValueTask.FromResult(TResult.Success("Mock Sign-up succeeded. You may now sign-in."));
	}

	public async ValueTask<TResult> LogOut()
	{
		User user = new();
		User = user;
		await SessionState.SetDataAsync<User>("auth", user);
		AppState.SetData(AppStateDataTags.TitleBarRightDrawerIcon, DrawerIconWhenLoggedOut);
		AppState.SetData(AppStateDataTags.TitleBarRightDrawerTitle, "Sign-In");
		await AppState.TriggerChangeAsync(AppStateDataTags.UserAuthUpdate);
		return TResult.Success("You have successfully signed out.");
	}

	public async ValueTask<TResult> UpdatePassword(string password, Guid? accountToken = null)
	{
		await Task.Delay(300);
		return TResult.Success("Your have successfully mocked updating your password.");
	}

	private ISessionState SessionState { get; }
	private IAppState AppState { get; }
}
