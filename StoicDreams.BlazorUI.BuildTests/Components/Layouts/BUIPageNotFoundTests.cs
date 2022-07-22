namespace StoicDreams.BlazorUI.Components.Layouts;

public class BUIPageNotFoundTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIPageNotFound> actions = ArrangeRenderTest<BUIPageNotFound>(_ => { }, this.StartupTestServices);

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("The page you are looking for could not be found");
		});
	}
}
