namespace StoicDreams.BlazorUI.Constants;

/// <summary>
/// TResult Status values that provide a generalized grouping of http response codes (e.g. 204 returned by request will be marked as Ok:200).
/// </summary>
public enum TResultStatus
{
	Exception = 0,
	Info = 100,
	Success = 200,
	Redirect = 300,
	ClientError = 400,
	ServerError = 500
}
