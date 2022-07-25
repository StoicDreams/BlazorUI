using StoicDreams.BlazorUI.Components.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoicDreams.BlazorUI.Components.Surfaces;

public class BUIDrawerPaperTests : TestFrameworkBlazor
{
	[Fact]
	public void Verify_Render()
	{
		IRenderActions<BUIDrawerPaper> actions = ArrangeRenderTest<BUIDrawerPaper>(options =>
		{
			options.Parameters.Add("ChildContent", MockRender("Mock Content"));
		});

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Mock Content");
		});
	}
}
