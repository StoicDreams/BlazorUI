namespace StoicDreams.BlazorUI.DataTypes;

public record ThemeConfig
{
	public string Name { get; set; } = "Custom";
	/// <summary>
	/// Milliseconds timing for navigation to transition pages in
	/// Defaults to 300
	/// </summary>
	public int NavTransitionIn { get; set; } = 300;
	/// <summary>
	/// Milliseconds timing for navigation to transition pages out
	/// </summary>
	public int NavTransitionOut { get; set; } = 300;
	/// <summary>
	/// Text / Offset color used against light backgrounds
	/// </summary>
	public ColorData Black { get; set; } = "#333333";
	/// <summary>
	/// Text / Offset color used against dark backgrounds
	/// </summary>
	public ColorData White { get; set; } = "#ffffff";
	public ColorData AppBarBackground { get; set; } = "#594ae2";
	public ColorData AppBackground { get; set; } = "#ffffff";
	public ColorData DrawerBackground { get; set; } = "#ffffff";
	public ColorData Primary { get; set; } = "#594ae2";
	public ColorData Secondary { get; set; } = "#ff4081";
	public ColorData Tertiary { get; set; } = "#1ec8a5";
	public ColorData Info { get; set; } = "#2196f3";
	public ColorData Success { get; set; } = "#00c853";
	public ColorData Warning { get; set; } = "#ff9800";
	public ColorData Error { get; set; } = "#f44336";
	public ColorData Dark { get; set; } = "#424242";

	public ThemeConfig Copy => new()
	{
		Name = Name,
		NavTransitionIn = NavTransitionIn,
		NavTransitionOut = NavTransitionOut,
		Black = Black.HexValue,
		White = White.HexValue,
		AppBarBackground = AppBarBackground.HexValue,
		DrawerBackground = DrawerBackground.HexValue,
		Primary = Primary.HexValue,
		Secondary = Secondary.HexValue,
		Tertiary = Tertiary.HexValue,
		Info = Info.HexValue,
		Success = Success.HexValue,
		Warning = Warning.HexValue,
		Error = Error.HexValue,
		Dark = Dark.HexValue,
	};

	public void CopyValues(ThemeConfig config)
	{
		Name = config.Name;
		NavTransitionIn = config.NavTransitionIn;
		NavTransitionOut = config.NavTransitionOut;
		Black = config.Black.HexValue;
		White = config.White.HexValue;
		AppBarBackground = config.AppBarBackground.HexValue;
		DrawerBackground = config.DrawerBackground.HexValue;
		Primary = config.Primary.HexValue;
		Secondary = config.Secondary.HexValue;
		Tertiary = config.Tertiary.HexValue;
		Info = config.Info.HexValue;
		Success = config.Success.HexValue;
		Warning = config.Warning.HexValue;
		Error = config.Error.HexValue;
		Dark = config.Dark.HexValue;
	}
}
