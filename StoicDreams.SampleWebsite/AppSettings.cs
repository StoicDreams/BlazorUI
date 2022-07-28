namespace StoicDreams.SampleWebsite;

public static class AppSettings
{
	public static void ApplyAppSettings(IAppOptions options)
	{
		options.AppName = "Blazor UI";
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
			appState.SetData(AppStateDataTags.RightDrawerOnClick, HandlerRightDrawerClickState(appState));
			appState.SetData(AppStateDataTags.TitleBarLeftDrawerTitle, "Toggle Navigation Menu");
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
				NavDetail.Create("Home", Icons.Material.TwoTone.Doorbell, "/docs/markdown"),
				NavDetail.Create("Home", Icons.Material.TwoTone.EmojiEmotions, "/docs/markdown/emojis"),
			})
		})
	};

	private static Func<DrawerClickState, ValueTask> HandlerRightDrawerClickState(IAppState appState)
	{
		return (DrawerClickState state) =>
		{
			if (state == DrawerClickState.Opening)
			{
				appState.SetData(AppStateDataTags.RightDrawerContent, typeof(SideContentSample));
			}
			return ValueTask.CompletedTask;
		};
	}
}
