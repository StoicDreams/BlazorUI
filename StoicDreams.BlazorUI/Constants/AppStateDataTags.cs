namespace StoicDreams.BlazorUI.Constants;

/// <summary>
/// Internal use IAppState data tag names.
/// </summary>
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
	/// Bool flag setting if title bar should be dense.
	/// Defaults to true
	/// </summary>
	DenseTitleBar,
	/// <summary>
	/// Bool flag setting if tables should be dense.
	/// Defaults to true
	/// </summary>
	DenseTables,
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
	/// Set bool if title bar uses dense setting (reduced padding)
	/// Defaults to false
	/// </summary>
	TitleBarIsDense,
	/// <summary>
	/// Integer value between 1 and 10 setting shadow amount for title bar.
	/// Defaults to 5
	/// </summary>
	TitleBarElevation,
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
	/// <summary>
	/// Title added to left drawer button for accessibility
	/// Defaults to "Toggle Left Drawer"
	/// </summary>
	TitleBarLeftDrawerTitle,
	/// <summary>
	/// Title added to right drawer button for accessibility
	/// Defaults to "Toggle Right Drawer"
	/// </summary>
	TitleBarRightDrawerTitle,
}
