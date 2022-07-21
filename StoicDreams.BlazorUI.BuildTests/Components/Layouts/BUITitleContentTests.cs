namespace StoicDreams.BlazorUI.Components.Layouts;

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
			a.GetService<IAppOptions>().AppName = "Test App";
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App").Should().BeFalse();
		});

		actions.Act(a =>
		{
			a.GetService<IAppState>().TriggerChange(AppStateDataTags.PageTitle.ToString());
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
			a.GetService<IAppState>().TriggerChange(AppStateDataTags.PageTitle.ToString());
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Contains("Test App - Test Title").Should().BeTrue();
		});
	}
}
