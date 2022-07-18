﻿namespace StoicDreams.BlazorUI.Data;

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
	#endregion

	#region Layout Configurations

	/// <summary>
	/// Use this to override using the DefaultLayout to manage your apps layout.
	/// </summary>
	/// <typeparam name="TLayout"></typeparam>
	void SetLayout<TLayout>() where TLayout : LayoutComponentBase;

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
