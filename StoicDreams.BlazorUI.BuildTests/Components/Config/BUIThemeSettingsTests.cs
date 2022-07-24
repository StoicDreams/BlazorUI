namespace StoicDreams.BlazorUI.Components.Config;

public class BUIThemeSettingsTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIThemeSettings> actions = ArrangeRenderTest<BUIThemeSettings>(options =>
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
