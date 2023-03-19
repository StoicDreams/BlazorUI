namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Options for app initialization.
/// These options set startup configuration values.
/// </summary>
public interface IAppOptions
{
	/// <summary>
	/// Name of your application.
	/// </summary>
	string AppName { get; set; }

	/// <summary>
	/// Name of your company.
	/// </summary>
	string CompanyName { get; set; }

	/// <summary>
	/// Set the url for the company website.
	/// This is used to create a link for the company name whenever it's displayed, such as in the default footer.
	/// </summary>
	string CompanyHomeUrl { get; set; }

	/// <summary>
	/// Root domains of your website (e.g. StoicDreams.com).
	/// Exclude use of www or other subdomains here.
	/// </summary>
	string Domain { get; set; }

	/// <summary>
	/// Start of copyright year for user displays.
	/// </summary>
	short CopyrightStart { get; set; }

	/// <summary>
	/// Set if this app is a website or application (mobile, desktop, etc).
	/// </summary>
	AppTypes AppType { get; set; }

	#region Startup settings
	/// <summary>
	/// Format expression for title tag.
	/// Defaults to "{AppName} - {PageTitle}"
	/// </summary>
	string TitleFormat { get; set; }

	/// <summary>
	/// Add href values here for css files to include during startup.
	/// These will be placed at the end of the head tag.
	/// </summary>
	IList<string> CssFiles { get; }

	/// <summary>
	/// Add src values here for javascript files to include during startup.
	/// These will be placed at the end of the body tag.
	/// </summary>
	IList<string> JavascriptFiles { get; }

	/// <summary>
	/// Add details for elements to add to head tag during startup.
	/// </summary>
	IList<ElementDetail> HeadElements { get; }

	/// <summary>
	/// Add details for elements to add to body tag during startup.
	/// </summary>
	IList<ElementDetail> BodyElements { get; }

	/// <summary>
	/// Run processing when the App is initializing.
	/// This is good for running Api checks or loading final configurations from an endpoint before allowing the app to start rendering operations.
	/// </summary>
	/// <param name="action"></param>
	void ApplyOnInit(Func<AppInitData, ValueTask> action);

	/// <summary>
	/// Apply a razor component to the app on startup.
	/// This should be a component that you want persisted for as long as the app is open.
	/// This is a good place to have app startup initializers such as auth/login checking, initial nav loading, etc.
	/// </summary>
	/// <typeparam name="TStartupComponent"></typeparam>
	void ApplyOnStartup<TStartupComponent>() where TStartupComponent : ComponentBase;

	/// <summary>
	/// Apply startup states during app initialization.
	/// </summary>
	/// <param name="action"></param>
	void ApplyStateOnStartup(Action<IAppState> action);
	#endregion

	#region Layout Configurations

	/// <summary>
	/// Use this to override using the DefaultLayout to manage your apps layout.
	/// </summary>
	/// <typeparam name="TLayout"></typeparam>
	void SetLayout<TLayout>() where TLayout : LayoutComponentBase;

	/// <summary>
	/// Use this to override title bar content between optional left and right drawer buttons.
	/// Default is BUITitleContent
	/// </summary>
	/// <typeparam name="TTitleBar"></typeparam>
	void SetTitleBarContent<TTitleBar>() where TTitleBar : ComponentBase;

	/// <summary>
	/// Use this to override the default BUIFooter component to use your own component for the sites footer.
	/// </summary>
	/// <typeparam name="TFooter"></typeparam>
	void SetFooter<TFooter>() where TFooter : ComponentBase;

	/// <summary>
	/// Change the component displayed when a user visits a page that doesn't match a mapped path.
	/// Defaults to BUIDefaultPageNotFound
	/// </summary>
	/// <typeparam name="TNotFound"></typeparam>
	void SetPageNotFound<TNotFound>() where TNotFound : ComponentBase;

	/// <summary>
	/// Change the default error page/component.
	/// Defaults to BUIError
	/// </summary>
	/// <typeparam name="TErrorPage"></typeparam>
	void SetErrorPage<TErrorPage>() where TErrorPage : ComponentBase, IErrorPage;

	/// <summary>
	/// Position for app's title bar.
	/// Default is Top.
	/// </summary>
	TitleBarPosition TitleBarPosition { get; set; }

	/// <summary>
	/// MudBlazor DrawerVariant used for left side drawer.
	/// </summary>
	DrawerVariant LeftDrawerVariant { get; set; }

	/// <summary>
	/// MudBlazor DrawerVariant used for right side drawer.
	/// </summary>
	DrawerVariant RightDrawerVariant { get; set; }
	#endregion
}
