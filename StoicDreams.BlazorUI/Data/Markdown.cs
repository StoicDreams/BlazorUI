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
		return ApplyMudBlazorClasses(Markdig.Markdown.ToHtml(markdown, Pipeline));
	}

	public MarkupString GetMarkup(string? markdown)
	{
		return new MarkupString(GetHtml(markdown));
	}

	private string ApplyMudBlazorClasses(string html) => html
		.Replace("<a href=", "<a class=\"mud-typography mud-link mud-primary-text mud-link-underline-hover mud-typography-body1\" href=")
		;

	private MarkdownPipeline Pipeline { get; set; }
}
