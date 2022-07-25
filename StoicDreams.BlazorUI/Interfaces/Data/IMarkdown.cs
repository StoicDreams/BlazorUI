namespace StoicDreams.BlazorUI.Data;

public interface IMarkdown
{
	string GetHtml(string? markdown);
	MarkupString GetMarkup(string? markdown);
}
