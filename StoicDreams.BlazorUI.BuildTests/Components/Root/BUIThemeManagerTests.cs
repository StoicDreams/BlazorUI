namespace StoicDreams.BlazorUI.Components.Root;

public class BUIThemeManagerTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIThemeManager> actions = ArrangeRenderTest<BUIThemeManager>(options =>
		{
		}, this.StartupTestServices);

		actions.Act(a =>
		{
		});

		actions.Assert(a =>
		{
		});
	}
}
