namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a section title page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static PageSegment SectionTitle(string text)
	{
		return PageSegment.Create<BUISectionTitle>(("ChildContent", text.ConvertToRenderFragment()));
	}
}
