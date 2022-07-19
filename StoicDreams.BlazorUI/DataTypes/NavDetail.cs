namespace StoicDreams.BlazorUI.DataTypes;

public class NavDetail
{
	/// <summary>
	/// Name displayed to users in nav button.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Icon value to use for icon display.
	/// </summary>
	public string Icon { get; set; } = string.Empty;

	/// <summary>
	/// Url path to navigate to on click.
	/// </summary>
	public string Href { get; set; } = string.Empty;

	/// <summary>
	/// Event to raise when button is click.
	/// </summary>
	public Action<NavDetail>? OnClick { get; set; }

	/// <summary>
	/// Create a new instance of NavDetail.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="icon"></param>
	/// <param name="href"></param>
	/// <param name="onClick"></param>
	/// <returns></returns>
	public static NavDetail Create(
		string name,
		string icon,
		string href,
		Action<NavDetail>? onClick = null
		)
	{
		return new()
		{
			Name = name,
			Icon = icon,
			Href = href,
			OnClick = onClick
		};
	}
}
