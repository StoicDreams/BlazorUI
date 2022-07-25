namespace StoicDreams.SampleWebsite.Pages.Docs.Markdown;

[Route("/docs/markdown")]
public class MarkdownHome : BUICorePage
{
	protected override Task OnInitializedAsync()
	{
		Title = "Markdown";
		PageMarkup.AddRange(new PageSegment[]
		{
			"## Blazor UI supports writing content using Markdown!",
			"This page will be the root of documenting Markdown support in Blazor UI.",
		});
		return base.OnInitializedAsync();
	}
}
