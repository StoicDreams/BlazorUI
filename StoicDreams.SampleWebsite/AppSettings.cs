using StoicDreams.BlazorUI.Data;

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
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "manifest")));
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "512x512"), ("href", "icon-512.png")));
		options.HeadElements.Add(ElementDetail.Create("link", ("rel", "apple-touch-icon"), ("sizes", "192x192"), ("href", "icon-192.png")));
		options.BodyElements.Add(ElementDetail.Create("script", ("body", "navigator.serviceWorker.register('service-worker.js');"), ("type", "text/javascript")));
		options.TitleBarPosition = TitleBarPosition.Top;
		options.LeftDrawerVariant = DrawerVariant.Mini;
		options.ApplyOnStartup<AppStartup>();
		options.ApplyStateOnStartup(appState =>
		{
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
		NavDetail.Create("Home", Icons.Material.TwoTone.Home, "/"),
		NavDetail.CreateGroup("Docs", Icons.Material.TwoTone.Source, new NavDetail[]
		{
			NavDetail.Create("Start", Icons.Material.TwoTone.LibraryBooks, "/docs/getting-started"),
			NavDetail.CreateGroup("Markdown", Icons.Material.TwoTone.Code, new NavDetail[]
			{
				NavDetail.Create("Markdown", Icons.Material.TwoTone.Doorbell, "/docs/markdown"),
				NavDetail.Create("Emojis", Icons.Material.TwoTone.EmojiEmotions, "/docs/markdown/emojis"),
			})
		}),
		NavDetail.Create("Terms", Icons.Material.TwoTone.Handshake, "/terms"),
		NavDetail.Create("Privacy", Icons.Material.TwoTone.PrivacyTip, "/privacy")
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
			sender.AppState.SetData(AppStateDataTags.RightDrawerContent, typeof(SideContentSample));
		}
		return ValueTask.CompletedTask;
	}
}
