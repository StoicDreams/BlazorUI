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
			SectionTitle("Project Goals"),
			StandardSection()
				.AddChild(Paragraph("This Blazor UI framework is targeting a developer experience that will allow developers to programatically develop websites and Maui Blazor apps (Desktop & Mobile) entirely through C# coding, without the need to touch any html, css, or javascript.")),
			SectionTitle("Current State of Development")
				.AddChild(Paragraph("This framework is very early in development, with a lot of experimental work being done to flesh out ideas and concepts that may or may not make it into the final product."))
				.AddChild(Paragraph("Because of this experimental stage in development, it can be expected that breaking changes will occur in any update, even within patch version updates. This will continue throughout the lifespan of 1.X versions of Blazor UI."))
				.AddChild(Paragraph("When we have reached a point of being satisfied that Blazor UI is ready for production use we will bump the version up to 2.0 and follow stricture versioning regimens going forward."))
		);
		return ValueTask.CompletedTask;
	}

}
