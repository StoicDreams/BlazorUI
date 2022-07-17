namespace StoicDreams.BlazorUI.Components;

public class StoicDreamsBlazorUIRootTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<StoicDreamsBlazorUIRoot> actions = ArrangeRenderTest<StoicDreamsBlazorUIRoot>(options =>
		{
			options.Parameters.Add("ChildContent", MockRender("Mock Content"));

		}, this.StartupTestServices);

		actions.Act();

		actions.Assert(a =>
		{
			a.DetachRender();
		});
	}
}
