using StoicDreams.BlazorUI;

namespace StoicDreams.BlazorUI.Components.Displays;

public class BUITitleContentTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUITitleContent> actions = ArrangeRenderTest<BUITitleContent>(options =>
		{

		}, this.StartupTestServices);

		actions.Act(a =>
		{
			a.GetService<IAppState>().SetData(AppStateDataTags.TitleBarShowAppName, true);
			a.GetService<IAppState>().SetData(AppStateDataTags.TitleBarShowPageTitle, true);
			a.GetService<IAppOptions>().AppName = "Test App";
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App").Should().BeFalse();
		});

		actions.Act(async a =>
		{
			await a.GetService<IAppState>().TriggerChangeAsync(AppStateDataTags.PageTitle.ToString());
			await Task.Delay(100);
			a.Render.SetParametersAndRender();
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App").Should().BeTrue();
		});

		actions.Act(a =>
		{
			a.GetService<IAppState>().SetData(AppStateDataTags.PageTitle, "Test Title");
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App - Test Title").Should().BeFalse();
		});

		actions.Act(a =>
		{
			a.GetService<IAppState>().TriggerChangeAsync(AppStateDataTags.PageTitle.ToString());
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App - Test Title").Should().BeTrue();
		});
	}
}
