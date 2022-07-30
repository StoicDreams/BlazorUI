namespace StoicDreams.SampleWebsite.Pages.Docs;

[Route("/docs/getting-started")]
[Route("/docs/gettingstarted")]
[Route("/docs/start")]
public class GettingStarted : BUIPage
{
	protected override Task InitializePage()
	{
		Title = "Getting Started";
		PageMarkup.AddRange(new PageSegment[]
		{
			"## Documentation - Getting Started",
			"Coming soon!",
		});
		return Task.CompletedTask;
	}
}
