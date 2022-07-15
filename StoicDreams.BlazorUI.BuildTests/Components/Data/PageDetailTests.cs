namespace StoicDreams.BlazorUI.Components.Data;

public class PageDetailTests : TestFrameworkBlazor
{
	[Theory]
	[InlineData("This is a test")]
	public void Verify_AppState_Updates_On_Render(string title)
	{
		IRenderActions<PageDetail> actions = ArrangeRenderTest<PageDetail>(options =>
		{
			options.Parameters["Title"] = title;
		}, this.StartupTestServices);

		actions.Act();

		actions.Assert(a =>
		{
			IAppState appState = a.GetService<IAppState>();
			appState.GetData<string>(AppStateDataTags.PageTitle).Should().Be(title);
		});
	}
}
