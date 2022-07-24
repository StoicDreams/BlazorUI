namespace StoicDreams.BlazorUI.Components.Dialogs;

public class BUIDialogEditTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDialogEdit> actions = ArrangeRenderTest<BUIDialogEdit>(options =>
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
