namespace StoicDreams.BlazorUI.Constants;

/// <summary>
/// Increment roles by bits (e.g. 1,2,4,8,16,32,64,etc.)
/// This system allows for up to 28 roles with simple tracking that allows users to be assigned multiple roles.
/// When a user is not logged in they essentially have no role and thus why Guest is valued at 0.
/// In other words, a user can never be a Guest with any other combined role.
/// </summary>
public enum GenericAuthRoles
{
	Guest = 0,
	User = 1,
	Admin = 2,
	Developer = 134_217_728
}
