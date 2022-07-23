namespace StoicDreams.BlazorUI.Constants;

public enum AppStateDataTags
{
	/// <summary>
	/// Set with DrawerVariant value
	/// Defaults to default enum value
	/// </summary>
	AppLeftDrawerVariant,
	/// <summary>
	/// Set with DrawerVariant value
	/// Defaults to default enum value
	/// </summary>
	AppRightDrawerVariant,
	/// <summary>
	/// Set with Func<DrawerClickState, ValueTask>
	/// Defaults to null
	/// </summary>
	LeftDrawerOnClick,
	/// <summary>
	/// Set with Type of ComponentBase
	/// Defaults to typeof(BUINavMenu)
	/// </summary>
	LeftDrawerContent,
	/// <summary>
	/// Set with List<NavDetail>
	/// Defaults with null
	/// </summary>
	NavList,
	/// <summary>
	/// Set with integer value
	/// Defaults to 300
	/// </summary>
	NavTransitionInMilliseconds,
	/// <summary>
	/// Set with integer value
	/// Defaults to 300
	/// </summary>
	NavTransitionOutMilliseconds,
	/// <summary>
	/// Set with string to use for page title
	/// </summary>
	PageTitle,
	/// <summary>
	/// Set with Func<DrawerClickState, ValueTask>
	/// Defaults to null
	/// </summary>
	RightDrawerOnClick,
	/// <summary>
	/// Set with Type of ComponentBase
	/// Defaults to typeof(BUINavMenu)
	/// </summary>
	RightDrawerContent,
	/// <summary>
	/// Bool value set internally when left drawer state is changed
	/// </summary>
	TitleBarLeftDrawerOpen,
	/// <summary>
	/// Set with string representing desired icon value
	/// Can use either an SVG value or font-awesome class (Support comes from MudBlazor Icon component)
	/// Defaults to null - title bar uses Icons.Material.Filled.Menu when null
	/// </summary>
	TitleBarLeftDrawerIcon,
	/// <summary>
	/// Bool value set internally when right drawer state is changed
	/// </summary>
	TitleBarRightDrawerOpen,
	/// <summary>
	/// Set with string representing desired icon value
	/// Can use either an SVG value or font-awesome class (Support comes from MudBlazor Icon component)
	/// Defaults to null - title bar uses Icons.Material.Filled.Menu when null
	/// </summary>
	TitleBarRightDrawerIcon,
}
