using Markdig;

namespace StoicDreams.BlazorUI.Data;

public class Markdown : IMarkdown
{
	public Markdown(MarkdownPipeline pipeline)
	{
		Pipeline = pipeline;
	}

	public string GetHtml(string? markdown)
	{
		if (string.IsNullOrWhiteSpace(markdown)) { return string.Empty; }
		return Markdig.Markdown.ToHtml(markdown, Pipeline);
	}

	public MarkupString GetMarkup(string? markdown)
	{
		return new MarkupString(GetHtml(markdown));
	}

	private MarkdownPipeline Pipeline { get; set; }
}
