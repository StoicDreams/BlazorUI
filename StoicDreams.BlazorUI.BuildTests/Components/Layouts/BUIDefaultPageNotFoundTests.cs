namespace StoicDreams.BlazorUI.Components.Layouts;

public class BUIDefaultPageNotFoundTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDefaultPageNotFound> actions = ArrangeRenderTest<BUIDefaultPageNotFound>(_ => { }, this.StartupTestServices);

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("The page you are looking for could not be found");
		});
	}
}
