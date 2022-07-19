namespace StoicDreams.BlazorUI.Components.Layouts;

public class DefaultLayoutTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDefaultLayout> actions = ArrangeRenderTest<BUIDefaultLayout>(options =>
		{

		}, this.StartupTestServices);

		actions.Act();

		actions.Assert(a =>
		{

		});
	}
}
