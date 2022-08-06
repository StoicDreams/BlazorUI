namespace StoicDreams.BlazorUI.Constants;

/// <summary>
/// Flag settings dictating permissions granted by user for how long their data can be stored within the app.
/// </summary>
public enum StoragePermissions
{
	/// <summary>
	/// Data will be stored in memory only.
	/// </summary>
	None,
	/// <summary>
	/// Limits data to current running instance.
	/// Websites will store data in sessionStorage.
	/// Applications will store data in memory - same as None
	/// </summary>
	CurrentInstance,
	/// <summary>
	/// No limits to data storage.
	/// Websites will store data in localtorage.
	/// Applicatoins will store data on disk.
	/// </summary>
	LongTerm
}
