namespace StoicDreams.SampleWebsite.Pages.Docs.Markdown;

[Route("/docs/markdown/emojis")]
public class MarkdownEmojis : BUICorePage
{
	protected override Task OnInitializedAsync()
	{
		Title = "Markdown Emojis";
		PageMarkup.AddRange(new PageSegment[]
		{
			"## Our Markdown supports Emojis :wink:!",
			"This page will document available emojis and how to use them.",
		});
		return base.OnInitializedAsync();
	}
}
