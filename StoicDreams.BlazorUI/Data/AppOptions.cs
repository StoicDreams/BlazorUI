namespace StoicDreams.BlazorUI.Data;

public sealed class AppOptions : IAppOptions
{
	public string AppName { get; set; } = string.Empty;
	public string CompanyName { get; set; } = string.Empty;
	public string CompanyHomeUrl { get; set; } = string.Empty;
	public string Domain { get; set; } = string.Empty;
	public short CopyrightStart { get; set; } = Convert.ToInt16(DateTime.UtcNow.Year);
	public AppTypes AppType { get; set; }

	#region Startup Options
	public Func<AppInitData, ValueTask>? OnAppInitialize { get; set; }
	public string TitleFormat { get; set; } = "{PageTitle} - {AppName}";
	public IList<string> CssFiles { get; } = new List<string>();
	public IList<string> JavascriptFiles { get; } = new List<string>();
	public IList<ElementDetail> HeadElements { get; } = new List<ElementDetail>();
	public IList<ElementDetail> BodyElements { get; } = new List<ElementDetail>();
	public Type? AppStartupComponent { get; set; }
	public void ApplyOnInit(Func<AppInitData, ValueTask> action)
	{
		OnAppInitialize = action;
	}
	public void ApplyOnStartup<TStartupComponent>()
		where TStartupComponent : ComponentBase
	{
		AppStartupComponent = typeof(TStartupComponent);
	}
	public Action<IAppState>? ApplyStartupState { get; set; }
	public void ApplyStateOnStartup(Action<IAppState> action)
	{
		ApplyStartupState = action;
	}
	#endregion

	#region Layout Options
	public Type MainLayout { get; set; } = typeof(BUIAppLayout);
	public void SetLayout<TLayout>()
		where TLayout : LayoutComponentBase
	{
		MainLayout = typeof(TLayout);
	}

	public Type PageNotFound { get; set; } = typeof(BUIPageNotFound);
	public void SetPageNotFound<TNotFound>()
		where TNotFound : ComponentBase
	{
		PageNotFound = typeof(TNotFound);
	}

	public Type ErrorPage { get; set; } = typeof(BUIError);
	public void SetErrorPage<TErrorPage>()
		where TErrorPage : ComponentBase, IErrorPage
	{
		ErrorPage = typeof(TErrorPage);
	}

	public Type TitleBarContent { get; set; } = typeof(BUITitleContent);
	public void SetTitleBarContent<TTitleBar>()
		where TTitleBar : ComponentBase
	{
		TitleBarContent = typeof(TTitleBar);
	}


	public Type Footer { get; set; } = typeof(BUIFooter);
	public void SetFooter<TFooter>()
		where TFooter : ComponentBase
	{
		Footer = typeof(TFooter);
	}

	public TitleBarPosition TitleBarPosition { get; set; }
	public DrawerVariant LeftDrawerVariant { get; set; } = DrawerVariant.Temporary;
	public DrawerVariant RightDrawerVariant { get; set; } = DrawerVariant.Temporary;
	#endregion
}
