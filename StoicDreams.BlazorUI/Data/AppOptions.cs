namespace StoicDreams.BlazorUI.Data;

public class AppOptions : IAppOptions
{
	public string AppName { get; set; } = string.Empty;
	public string TitleFormat { get; set; } = "{AppName} - {PageTitle}";
	public IList<string> CssFiles { get; } = new List<string>();
	public IList<string> JavascriptFiles { get; } = new List<string>();
	public IList<ElementDetail> HeadElements { get; } = new List<ElementDetail>();
	public IList<ElementDetail> BodyElements { get; } = new List<ElementDetail>();
	public void SetLayout<TLayout>()
		where TLayout : LayoutComponentBase
	{
		MainLayout = typeof(TLayout);
	}
	public Type MainLayout { get; set; } = typeof(DefaultLayout);
}
