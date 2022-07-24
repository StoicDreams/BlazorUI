namespace StoicDreams.BlazorUI.Components.Config;

public class BUIAppSettingsTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIAppSettings> actions = ArrangeRenderTest<BUIAppSettings>(options =>
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
