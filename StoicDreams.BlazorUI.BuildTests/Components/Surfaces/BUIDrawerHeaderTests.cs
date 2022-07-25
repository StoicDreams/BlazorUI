namespace StoicDreams.BlazorUI.Components.Surfaces;

public class BUIDrawerHeaderTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDrawerHeader> actions = ArrangeRenderTest<BUIDrawerHeader>(options =>
		{
			options.Parameters.Add("ChildContent", MockRender("Mock Content"));
		});

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Mock Content");
		});
	}
}
