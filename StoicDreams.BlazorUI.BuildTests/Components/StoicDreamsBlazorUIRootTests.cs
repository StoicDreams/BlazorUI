using Microsoft.AspNetCore.Components;

namespace StoicDreams.BlazorUI.Components;

public class StoicDreamsBlazorUIRootTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIRoot> actions = ArrangeRenderTest<BUIRoot>(options =>
		{
			options.Parameters.Add("ChildContent", MockRender("Mock Content"));
		}, this.StartupTestServices);

		actions.Act(a =>
		{
			a.GetService<IAppState>().TriggerChange("PageTitle");
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Mock Content");
		});

		actions.Act(a =>
		{
			a.DetachRender();
		});

		actions.Assert(a =>
		{
			a.Render.IsDisposed.Should().BeTrue();
		});
	}
}
