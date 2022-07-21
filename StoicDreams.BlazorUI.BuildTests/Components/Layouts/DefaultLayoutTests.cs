namespace StoicDreams.BlazorUI.Components.Layouts;

public class DefaultLayoutTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIAppLayout> actions = ArrangeRenderTest<BUIAppLayout>(options =>
		{

		}, this.StartupTestServices);

		actions.Act();

		actions.Assert(a =>
		{

		});
	}
}
