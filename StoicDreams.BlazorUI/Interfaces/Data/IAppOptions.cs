namespace StoicDreams.BlazorUI.Data;

public interface IAppOptions
{
	/// <summary>
	/// Name of your application.
	/// </summary>
	string AppName { get; set; }

	/// <summary>
	/// Format expression for title tag.
	/// Defaults to "{AppName} - {PageTitle}"
	/// </summary>
	string TitleFormat { get; set; }

	/// <summary>
	/// Add href values here for css files to include.
	/// These will be placed at the end of the head tag.
	/// </summary>
	IList<string> CssFiles { get; }

	/// <summary>
	/// Add src values here for javascript files to include.
	/// These will be placed at the end of the body tag.
	/// </summary>
	IList<string> JavascriptFiles { get; }

	/// <summary>
	/// Add details for elements to add to head tag.
	/// </summary>
	IList<ElementDetail> HeadElements { get; }

	/// <summary>
	/// Add details for elements to add to body tag.
	/// </summary>
	IList<ElementDetail> BodyElements { get; }

	void SetLayout<TLayout>() where TLayout : LayoutComponentBase;
}
