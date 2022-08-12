namespace StoicDreams.BlazorUI.DataTypes;

public class NavDetail
{
	/// <summary>
	/// Name displayed to users in nav button.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Roles required to access page.
	/// 0 is guest / public
	/// Other roles need to use Ids that are offset by bits (1, 2, 4, 8, 16, etc) which allows for users to be assigne multiple roles.
	/// </summary>
	public int Roles { get; set; } = 0;

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
		int roles = 0,
		Action<NavDetail>? onClick = null
		)
	{
		return new()
		{
			Name = name,
			Icon = icon,
			Href = href,
			Roles = roles,
			OnClick = onClick
		};
	}

	public static NavDetail CreateGroup(
		string name,
		string icon,
		int roles,
		IEnumerable<NavDetail> subNav
		)
	{
		NavDetail instance =  new()
		{
			Name = name,
			Icon = icon,
			Roles = roles
		};
		instance.SubNav.AddRange(subNav);
		return instance;
	}
}
