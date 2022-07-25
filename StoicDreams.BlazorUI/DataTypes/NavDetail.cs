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
	/// Returns true if this instance contains SubNav items.
	/// </summary>
	public bool IsNavGroup => SubNav.Count > 0;

	/// <summary>
	/// Populate to use button as a group container.
	/// </summary>
	public List<NavDetail> SubNav { get; set; } = new();

	/// <summary>
	/// Url path to navigate to on click.
	/// Not used if SubNav is populated.
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

	public static NavDetail CreateGroup(
		string name,
		string icon,
		IEnumerable<NavDetail> subNav
		)
	{
		NavDetail instance =  new()
		{
			Name = name,
			Icon = icon,
		};
		instance.SubNav.AddRange(subNav);
		return instance;
	}
}
