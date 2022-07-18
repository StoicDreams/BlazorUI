namespace StoicDreams.BlazorUI.Data;

public class AppOptions : IAppOptions
{
	public string AppName { get; set; } = string.Empty;
	#region Startup Options
	public string TitleFormat { get; set; } = "{AppName} - {PageTitle}";
	public IList<string> CssFiles { get; } = new List<string>();
	public IList<string> JavascriptFiles { get; } = new List<string>();
	public IList<ElementDetail> HeadElements { get; } = new List<ElementDetail>();
	public IList<ElementDetail> BodyElements { get; } = new List<ElementDetail>();
	#endregion

	#region Layout Options
	public void SetLayout<TLayout>()
		where TLayout : LayoutComponentBase
	{
		MainLayout = typeof(TLayout);
	}
	public Type MainLayout { get; set; } = typeof(DefaultLayout);
	public TitleBarPosition TitleBarPosition { get; set; }
	public DrawerVariant LeftDrawerVariant { get; set; } = DrawerVariant.Temporary;
	public DrawerVariant RightDrawerVariant { get; set; } = DrawerVariant.Temporary;
	#endregion
}
