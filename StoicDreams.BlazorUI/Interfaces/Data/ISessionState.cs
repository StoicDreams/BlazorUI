namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Data storage relevant to the current user's current session.
/// By default, data is stored in memory, so if the user refreshes a webpage, or closes and opens the app, a new session will start.
/// Beyond this, users are required to accept the appropriate storage mechanism to save their information on the device they are using.
/// For web browser apps, data will be stored in either of the browser's sessionStorage or localStorage containers when the user has acknowledged the appropriate acceptance.
/// For mobile|desktop apps, data will be stored on the local device.
/// </summary>
public interface ISessionState : IStateManager
{
}
