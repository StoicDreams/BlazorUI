namespace StoicDreams.BlazorUI.Components.Layouts;

public class BUINavMenuTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUINavMenu> actions = ArrangeRenderTest<BUINavMenu>(options =>
		{
		}, this.StartupTestServices);

		actions.Act(a =>
		{
		});

		actions.Assert(a =>
		{
			a.Render.HasComponent<MudNavMenu>().Should().BeTrue();
		});
	}
}
