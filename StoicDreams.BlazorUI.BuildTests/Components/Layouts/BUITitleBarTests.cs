using Microsoft.AspNetCore.Components;

namespace StoicDreams.BlazorUI.Components.Layouts;

public class BUITitleBarTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUITitleBar> actions = ArrangeRenderTest<BUITitleBar>(options =>
		{
		}, this.StartupTestServices);

		actions.Act(a =>
		{
		});

		actions.Assert(a =>
		{
			a.Render.Find(".buiTitleBar").Should().IsNotNull();
		});
	}
}
