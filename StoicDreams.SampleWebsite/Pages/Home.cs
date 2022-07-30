namespace StoicDreams.SampleWebsite.Pages;

[Route("/")]
[Route("/home")]
public class Home : BUIPage
{
	protected override Task InitializePage()
	{
		Title = "Welcome";
		PageMarkup.AddRange(new PageSegment[]
		{
			PageSegment.Create<MudPaper>(new Dictionary<string, object>()
			{
				{ "Class", "d-flex flex-row" },
				{ "Elevation", 0 }
			}, new PageSegment[]
			{
				PageSegment.Create<MudPaper>(new Dictionary<string, object>()
				{
					{ "Class", "flex-grow-1 mt-2" },
					{ "Elevation", 0 }
				}, new PageSegment[]
				{
					PageSegment.Create<BUISectionTitle>(("ChildContent", "You have reached the Demo and Documentation website for Blazor UI from Stoic Dreams!".ConvertToRenderFragment()))
				}),
				PageSegment.Create<MudPaper>(new Dictionary<string, object>()
				{
					{ "Class", "d-flex flex-wrap gap-2 mt-2 mb-3 ml-4 justify-end" },
					{ "Elevation", 0 }
				}, new PageSegment[]
				{
					BuildButtonLink("GitHub", "https://GitHub.com/StoicDreams/BlazorUI", Icons.Custom.Brands.GitHub),
					BuildButtonLink("Nuget", "https://NuGet.org/packages/StoicDreams.BlazorUI", Icons.Material.TwoTone.Store)
				})
			}),
			PageSegment.Create<BUIStandardSection>(new Dictionary<string, object>(), new PageSegment[]
			{
				PageSegment.Create<BUIParagraph>(new Dictionary<string, object>()
				{
					{ "ChildContent", "This website is being developed in conjuction with our new Blazor UI framework.".ConvertToRenderFragment() }
				}),
				PageSegment.Create<BUIParagraph>(new Dictionary<string, object>()
				{
					{ "ChildContent", "We want to emphasize that this is a true framework and not a component library. The goal of Blazor UI is to provide a pre-defined structure as a starting point so developers can focus on just adding site content.".ConvertToRenderFragment() }
				})
			}),
			PageSegment.Create<BUISectionTitle>(new Dictionary<string, object>()
			{
				{ "ChildContent", "Project Goals".ConvertToRenderFragment() }
			})
		});
		return Task.CompletedTask;
	}

	private PageSegment BuildButtonLink(string text, string href, string? startIcon = null)
	{
		Dictionary<string, object> parameters = new()
		{
			{ "Variant", Variant.Filled },
			{ "ChildContent", text.ConvertToRenderFragment() },
			{ "Href", href },
			{ "Size", Size.Small },
			{ "Color", Color.Info },
			{ "Target", "_blank" },
			{ "EndIcon", Icons.Material.TwoTone.OpenInNew },
			{ "title", href.Replace("https://", "") }
		};
		if (!string.IsNullOrWhiteSpace(startIcon)) { parameters.Add("StartIcon", startIcon); }
		return PageSegment.Create<MudButton>(parameters);
	}
}
