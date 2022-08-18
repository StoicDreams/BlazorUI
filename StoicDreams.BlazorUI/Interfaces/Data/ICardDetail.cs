namespace StoicDreams.BlazorUI.Data;

public interface ICardDetail
{
	/// <summary>
	/// Path to image, svg html, or font-awesome icon class
	/// </summary>
	string Avatar { get; set; }

	/// <summary>
	/// Alt text to display when user mouses over Avatar or image is not loadable.
	/// </summary>
	string AvatarAltText { get; set; }

	/// <summary>
	/// Avatar color
	/// </summary>
	Color AvatarColor { get; set; }

	/// <summary>
	/// Content to render in card header (top third)
	/// </summary>
	RenderFragment? Header { get; set; }

	/// <summary>
	/// Set color for header background
	/// </summary>
	Color HeaderTheme { get; set; }

	/// <summary>
	/// Set with action to use for header action button.
	/// </summary>
	EventCallback HeaderAction { get; set; }

	/// <summary>
	/// Set with URL to use header action icon as a link.
	/// </summary>
	string HeaderLink { get; set; }

	/// <summary>
	/// Set icon to use for header action button.
	/// Will not display if HeaderAction and HeaderLink is not set.
	/// If HeaderLink is an external url (starts with http) then a Link icon will be used instead of this.
	/// </summary>
	string HeaderIcon { get; set; }

	/// <summary>
	/// Main content to render in card body (mid third)
	/// </summary>
	RenderFragment? Content { get; set; }

	/// <summary>
	/// Content to render in card actions section (bottom third)
	/// </summary>
	RenderFragment? Actions { get; set; }
}
