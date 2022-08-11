namespace StoicDreams.BlazorUI.Constants;

/// <summary>
/// Internal use IAppState data tag names.
/// </summary>
public enum AppStateDataTags
{
	/// <summary>
	/// Type dictating content to display in side bar when user clicks Settings icon in title bar.
	/// Defaults to BUIAppSettings
	/// </summary>
	AppSettingsComponent,
	/// <summary>
	/// Type component allowing extra content to be added within BUIAppSettings display
	/// </summary>
	AppSettingsSubComponent,
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
	/// Bool flag setting if breadcrumb display should be shown.
	/// Default setup enables this.
	/// </summary>
	BreadcrumbEnabled,
	/// <summary>
	/// String of current page path (e.g. "/home").
	/// Excludes any query data
	/// </summary>
	CurrentPage,
	/// <summary>
	/// Bool flag setting if tables should be dense.
	/// Defaults to true
	/// </summary>
	DenseTables,
	/// <summary>
	/// Default message to display when the error page/component is displayed.
	/// </summary>
	ErrorPageDefaultMessage,
	/// <summary>
	/// Bool value indicating when page loading or navigation is in progress.
	/// Framework sets true when navigation has started and set false when page title has been set.
	/// Developers should also update this state explicitly when loading page content.
	/// </summary>
	IsLoadingPage,
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
	/// Minimum time to show navigation progress bar in milliseconds.
	/// Defaults to 600 (0.6 second)
	/// </summary>
	MinNavTransitionProgressDisplay,
	/// <summary>
	/// Set with List<NavDetail>
	/// Defaults with null
	/// </summary>
	NavList,
	/// <summary>
	/// Set color for active item in nav menu
	/// </summary>
	NavMenuActiveColor,
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
	/// Default message to use by not found page/component when displayed
	/// </summary>
	NotFoundDefaultMessage,
	/// <summary>
	/// Set with string to use for page title
	/// </summary>
	PageTitle,
	/// <summary>
	/// Type of component to use for Privacy Page content.
	/// Defaults to BUIPrivacyPageContent
	/// </summary>
	PrivacyPageContent,
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
	/// Holds StoragePermissions flag value.
	/// This is expected to only be updated with user consent when they permit storing data on their device.
	/// </summary>
	StoragePermission,
	/// <summary>
	/// Type of component to use for Terms page content.
	/// Defaults to BUITermsPageContent.
	/// </summary>
	TermsPageContent,
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
	/// Set with string | RenderFragment to display content to the left of the Title Display
	/// </summary>
	TitleBarLogo,
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
	/// <summary>
	/// bool flag - set true to display app name in title bar, false to not.
	/// </summary>
	TitleBarShowAppName,
	/// <summary>
	/// bool flag - set true to display page title in title bar, false to not.
	/// </summary>
	TitleBarShowPageTitle,
	/// <summary>
	/// Type of component to use for displaying content on the right side of the title bar
	/// Defaults to BUITitleBarQuickLinks
	/// </summary>
	TitleBarRightSideContent,
	/// <summary>
	/// Trigger to use anytime User data or any other auth information is updated.
	/// </summary>
	UserAuthUpdate,
}
