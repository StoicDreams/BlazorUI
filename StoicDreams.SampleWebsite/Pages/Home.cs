namespace StoicDreams.SampleWebsite.Pages;

[Route("/")]
[Route("/home")]
public class Home : BUIPage
{
	protected override ValueTask InitializePage()
	{
		Title = "Welcome";
		SetPageContent(
			Paper(PaperTypes.FlexRow)
				.AddChild(Paper(PaperTypes.Grow, "mt-2")
					.AddChild(SectionTitle("You have reached the Demo and Documentation website for Blazor UI from Stoic Dreams!"))
					)
				.AddChild(Paper(PaperTypes.Wrap | PaperTypes.JustifyEnd, "gap-2 mt-2 mb-3 ml-4")
					.AddChild(ButtonLink("GitHub", "https://GitHub.com/StoicDreams/BlazorUI", Icons.Custom.Brands.GitHub))
					.AddChild(ButtonLink("Nuget", "https://NuGet.org/packages/StoicDreams.BlazorUI", Icons.Material.TwoTone.Store))
					),
			StandardSection()
				.AddChild(Paragraph("This website is being developed in conjuction with our new Blazor UI framework."))
				.AddChild(Paragraph("We want to emphasize that this is a true framework and not a component library. The goal of Blazor UI is to provide a pre-defined structure as a starting point so developers can focus on just adding site content.")),
			SectionTitle("Project Goals")
		);
		return ValueTask.CompletedTask;
	}

}
