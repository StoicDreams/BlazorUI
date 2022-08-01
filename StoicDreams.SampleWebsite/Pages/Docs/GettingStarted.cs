namespace StoicDreams.SampleWebsite.Pages.Docs;

[Route("/docs/getting-started")]
[Route("/docs/gettingstarted")]
[Route("/docs/start")]
public class GettingStarted : BUIPage
{
	protected override ValueTask InitializePage()
	{
		Title = "Getting Started";
		SetPageContent(
			SectionTitle("Documentation - Getting Started"),
			StandardSection(
				"Welcome to the Stoic Dreams Blazor UI documentation."
				)
		);
		return ValueTask.CompletedTask;
	}
}
