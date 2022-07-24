namespace StoicDreams.BlazorUI.Components.Dialogs;

public class BUIDialogConfirmTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDialogConfirm> actions = ArrangeRenderTest<BUIDialogConfirm>(options =>
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
