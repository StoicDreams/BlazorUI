using Microsoft.AspNetCore.Components;
using StoicDreams.BlazorUI;

namespace StoicDreams.BlazorUI.Components.Displays;

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
			a.Render.Render();
		});

		actions.Assert(a =>
		{
			a.Render.Find(".buiTitleBar").Should().IsNotNull();
		});
	}
}
