namespace StoicDreams.SampleWebsite;

public static class AppSettings
{
	public static void ApplyAppSettings(IAppOptions options)
	{
		options.AppName = "Blazor UI";
		options.CompanyName = "Stoic Dreams";
		options.Domain = "StoicDreams.com";
		options.AppType = AppTypes.Website;
		options.CssFiles.Add("css/app.css");
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "manifest"), ("href", "app.webmanifest")));
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "512x512"), ("href", "icon-512.png")));
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "192x192"), ("href", "icon-192.png")));
		options.BodyElements.Add(ElementDetail.Create("script", ("body", "navigator.serviceWorker.register('service-worker.js');"), ("type", "text/javascript")));
		options.TitleBarPosition = TitleBarPosition.Top;
		options.LeftDrawerVariant = DrawerVariant.Mini;
		options.ApplyOnStartup<AppStartup>();
		options.ApplyStateOnStartup(appState =>
		{
			appState.SetData(AppStateDataTags.FeedbackComponent, typeof(Feedback));
			appState.SetData(AppStateDataTags.TitleBarLogo, "<img src=\"BlazorUI.svg\" title=\"Blazor UI Logo\" aria-label=\"Blazor UI Logo\" />");
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
		NavDetail.CreateGroup("Account", Icons.Material.TwoTone.AccountCircle, UserRoles.User, new NavDetail[]
		{
			NavDetail.Create("My Info", Icons.Material.TwoTone.VerifiedUser, "/account/myinfo", UserRoles.User),
		}),
		NavDetail.CreateGroup("Docs", Icons.Material.TwoTone.Source, UserRoles.Guest, new NavDetail[]
		{
			NavDetail.Create("Start", Icons.Material.TwoTone.LibraryBooks, "/docs/getting-started", UserRoles.Guest),
			NavDetail.CreateGroup("Markdown", Icons.Material.TwoTone.Code, UserRoles.Guest, new NavDetail[]
			{
				NavDetail.Create("Markdown", Icons.Material.TwoTone.Doorbell, "/docs/markdown", UserRoles.Guest),
				NavDetail.Create("Emojis", Icons.Material.TwoTone.EmojiEmotions, "/docs/markdown/emojis", UserRoles.Guest),
			})
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
