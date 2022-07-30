namespace StoicDreams.SampleWebsite.Pages.Docs.Markdown;

[Route("/docs/markdown")]
public class MarkdownHome : BUIPage
{
	protected override ValueTask InitializePage()
	{
		Title = "Markdown";
		SetPageContent(
			SectionTitle("Blazor UI supports writing content using Markdown!"),
			Paragraph("This page will be the root of documenting Markdown support in Blazor UI.")
		);
		return ValueTask.CompletedTask;
	}
}
