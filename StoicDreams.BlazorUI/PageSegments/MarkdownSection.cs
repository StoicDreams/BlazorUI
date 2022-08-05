namespace StoicDreams.BlazorUI.Components.Content;

public abstract partial class BUIDynamicContent
{
	/// <summary>
	/// Create a page section from markdown content.
	/// </summary>
	/// <param name="markdown"></param>
	/// <returns></returns>
	public static PageSegment MarkdownSection(string markdown)
	{
		return PageSegment.Create<BUIMarkdown>((nameof(BUIMarkdown.Markup), markdown));
	}
}
