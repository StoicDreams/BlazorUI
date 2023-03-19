namespace StoicDreams.SampleWebsite;

public static class AppSettings
{
	public static IServiceCollection WebStartup(this IServiceCollection services)
	{
		services.AddStoicDreamsBlazorUI(ApplyAppSettings);
		return services;
	}

	public static void ApplyAppSettings(IAppOptions options)
	{
		options.AppName = "Blazor UI";
		options.CompanyName = "Stoic Dreams";
		options.CompanyHomeUrl = "https://www.stoicdreams.com";
		options.Domain = "StoicDreams.com";
		options.AppType = AppTypes.Website;
		options.CopyrightStart = 2022;
		options.TitleBarPosition = TitleBarPosition.Top;
		options.LeftDrawerVariant = DrawerVariant.Mini;
		options.ApplyOnStartup<AppStartup>();
		options.ApplyStateOnStartup(appState =>
		{
			appState.SetData(AppStateDataTags.FeedbackComponent, typeof(Feedback));
			appState.SetData(AppStateDataTags.TitleBarLogo, "<img src=\"Logo.svg\" title=\"Blazor UI Logo\" aria-label=\"Blazor UI Logo\" />");
			appState.SetData(AppStateDataTags.NavList, GetSiteNavigation());
			appState.SetData(AppStateDataTags.RightDrawerOnClick, HandlerRightDrawerClickState);
			appState.SetData(AppStateDataTags.TitleBarRightDrawerIcon, Icons.Material.TwoTone.Login);
			appState.SetData(AppStateDataTags.TitleBarRightDrawerTitle, "Sign-In");
			appState.SetData(AppStateDataTags.TitleBarLeftDrawerTitle, "Toggle Navigation Menu");
			appState.SetData(AppStateDataTags.TitleBarRightSideContent, typeof(TitleBarStrip));
		});
	}

	private static List<NavDetail> GetSiteNavigation() => new()
	{
		NavDetail.Create("Home", Icons.Material.TwoTone.Home, "/", UserRoles.Guest),
		NavDetail.Create("Get Started", Icons.Material.TwoTone.LibraryBooks, "/getting-started", UserRoles.Guest),
		NavDetail.CreateGroup("Content", Icons.Material.TwoTone.Feed, UserRoles.Guest, new NavDetail[]
		{
			NavDetail.Create("Page Sections", Icons.Material.TwoTone.HorizontalSplit, "/content/pagesections", UserRoles.Guest),
		}),
		NavDetail.CreateGroup("Markdown", Icons.Material.TwoTone.Code, UserRoles.Guest, new NavDetail[]
		{
			NavDetail.Create("Markdown", Icons.Material.TwoTone.Doorbell, "/markdown", UserRoles.Guest),
			NavDetail.Create("Emojis", Icons.Material.TwoTone.EmojiEmotions, "/markdown/emojis", UserRoles.Guest),
		}),
		NavDetail.CreateGroup("User Input", Icons.Material.TwoTone.Input, UserRoles.Guest, new NavDetail[]
		{
			NavDetail.Create("Input Chips", Icons.Material.TwoTone.MoreHoriz, "/userinput/inputchips", UserRoles.Guest),
		}),
		NavDetail.CreateGroup("Account", Icons.Material.TwoTone.AccountCircle, UserRoles.User, new NavDetail[]
		{
			NavDetail.Create("My Info", Icons.Material.TwoTone.VerifiedUser, "/account/myinfo", UserRoles.User),
		}),
		NavDetail.Create("Terms", Icons.Material.TwoTone.Handshake, "/terms", UserRoles.Guest),
		NavDetail.Create("Privacy", Icons.Material.TwoTone.PrivacyTip, "/privacy", UserRoles.Guest)
	};

	private static ValueTask HandlerRightDrawerClickState(BUICore sender, DrawerClickState clickState)
	{
		if (!sender.Auth.IsLoggedIn)
		{
			sender.NavManager.NavigateTo("/signin");
			sender.AppState.SetData(AppStateDataTags.TitleBarRightDrawerOpen, false);
			return ValueTask.CompletedTask;
		}
		if (clickState == DrawerClickState.Opening)
		{
			sender.AppState.SetData(AppStateDataTags.RightDrawerContent, typeof(AccountPortal));
		}
		return ValueTask.CompletedTask;
	}
}
