namespace StoicDreams.SampleWebsite.Pages;

[Route("/")]
[Route("/home")]
public class Index : BUICorePage
{
	protected override Task OnInitializedAsync()
	{
		Title = "Welcome";
		PageMarkup.AddRange(new PageSegment[]
		{
			@"
## You have reached the Demo and Documentation website for Blazor UI from Stoic Dreams!
###### GitHub: [GitHub.com/StoicDreams/BlazorUI](https://github.com/StoicDreams/BlazorUI)
###### Nuget: [NuGet.org/StoicDreams/BlazorUI](https://nuget.org/StoicDreams/BlazorUI)
###### Demo & Docs: [blazorui.stoicdreams.com](https://blazorui.stoicdreams.com)

This website is being developed in conjuction with our new Blazor UI framework.

We are very excited about this project and what it means for our development with our other projects and helping to ease the adoption of the Blazor framework.

Stay tuned for more content coming soon :smile:!
"
		});

		return base.OnInitializedAsync();
	}
}
