using System.Text.Json.Serialization;

namespace StoicDreams.BlazorUI.DataTypes;

public record ThemeConfig
{
	public Guid Id { get; } = Guid.NewGuid();

	public string Name { get; set; } = "Custom";

	/// <summary>
	/// Milliseconds timing for navigation to transition pages in
	/// Defaults to 300
	/// </summary>
	[Display("Nav Transition In")]
	public int NavTransitionIn { get; set; } = 300;


	/// <summary>
	/// Milliseconds timing for navigation to transition pages out
	/// </summary>
	[Display("Nav Transition Out")]
	public int NavTransitionOut { get; set; } = 300;
	/// <summary>
	/// Text / Offset color used against light backgrounds
	/// </summary>
	[Display("Text color for Light Backgrounds")]
	public ColorData Black { get; set; } = "#333333";
	/// <summary>
	/// Text / Offset color used against dark backgrounds
	/// </summary>
	[Display("Text color for Dark Backgrounds")]
	public ColorData White { get; set; } = "#ffffff";
	[Display("Title Bar Background")]
	public ColorData AppBarBackground { get; set; } = "#594ae2";
	[Display("Main Body Background")]
	public ColorData AppBackground { get; set; } = "#ffffff";
	[Display("Drawer Background")]
	public ColorData DrawerBackground { get; set; } = "#ffffff";
	[Display("Primary Color")]
	public ColorData Primary { get; set; } = "#594ae2";
	[Display("Secondary Color")]
	public ColorData Secondary { get; set; } = "#ff4081";
	[Display("Tertiary Color")]
	public ColorData Tertiary { get; set; } = "#1ec8a5";
	[Display("Info Alerts / Classes")]
	public ColorData Info { get; set; } = "#2196f3";
	[Display("Success Alerts / Classes")]
	public ColorData Success { get; set; } = "#00c853";
	[Display("Warning Alerts / Classes")]
	public ColorData Warning { get; set; } = "#ff9800";
	[Display("Error Alerts / Classes")]
	public ColorData Error { get; set; } = "#f44336";
	[Display("Dark")]
	public ColorData Dark { get; set; } = "#424242";

	private Guid GuidFromName(string name) => IntToGuid(name.GetStaticHashCode());

	private Guid IntToGuid(int value)
	{
		byte[] bytes = new byte[16];
		BitConverter.GetBytes(value).CopyTo(bytes, 0);
		return new Guid(bytes);
	}

	[JsonIgnore]
	/// <summary>
	/// Return a new instance of this theme config with values copied
	/// </summary>
	public ThemeConfig Copy => new()
	{
		Name = Name,
		NavTransitionIn = NavTransitionIn,
		NavTransitionOut = NavTransitionOut,
		Black = Black.HexValue,
		White = White.HexValue,
		AppBarBackground = AppBarBackground.HexValue,
		AppBackground = AppBackground.HexValue,
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

	/// <summary>
	/// Copy values from the passed config to this config.
	/// </summary>
	/// <param name="config"></param>
	public void CopyValues(ThemeConfig config)
	{
		Name = config.Name;
		NavTransitionIn = config.NavTransitionIn;
		NavTransitionOut = config.NavTransitionOut;
		Black = config.Black.HexValue;
		White = config.White.HexValue;
		AppBarBackground = config.AppBarBackground.HexValue;
		AppBackground = config.AppBackground.HexValue;
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
