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
			"## Documentation - Getting Started",
			"Coming soon!"
		);
		return ValueTask.CompletedTask;
	}
}
