namespace StoicDreams.SampleWebsite.Pages.Docs.Markdown;

[Route("/docs/markdown")]
public class MarkdownHome : BUIPage
{
	protected override Task InitializePage()
	{
		Title = "Markdown";
		PageMarkup.AddRange(new PageSegment[]
		{
			"## Blazor UI supports writing content using Markdown!",
			"This page will be the root of documenting Markdown support in Blazor UI.",
		});
		return Task.CompletedTask;
	}
}
