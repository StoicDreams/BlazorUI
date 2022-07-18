namespace StoicDreams.BlazorUI.Components.Layouts;

public class DefaultLayoutTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<DefaultLayout> actions = ArrangeRenderTest<DefaultLayout>(options =>
		{

		}, this.StartupTestServices);

		actions.Act();

		actions.Assert(a =>
		{

		});
	}
}
