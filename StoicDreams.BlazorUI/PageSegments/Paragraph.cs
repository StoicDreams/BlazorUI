namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a new paragraph page segment.
	/// </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	public static PageSegment Paragraph(string text)
	{
		return PageSegment.Create<BUIParagraph>(("ChildContent", text.ConvertToRenderFragment()));
	}
}
