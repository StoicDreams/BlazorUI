namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
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
