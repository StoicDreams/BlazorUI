namespace StoicDreams.BlazorUI.Components.Base;

public abstract partial class BUIPage
{
	/// <summary>
	/// Create a page section from markdown content.
	/// </summary>
	/// <param name="markdown"></param>
	/// <returns></returns>
	public static PageSegment MarkdownSection(string markdown)
	{
		return PageSegment.Create<BUIMarkdown>(("Markup", markdown));
	}
}
