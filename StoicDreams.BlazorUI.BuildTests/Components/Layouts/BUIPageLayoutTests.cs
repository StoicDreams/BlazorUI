using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using Transition = BlazorTransitionableRoute.Transition;

namespace StoicDreams.BlazorUI.Components.Layouts;

public class BUIPageLayoutTests : TestFrameworkBlazor
{
	[Theory]
	[InlineData("", true, false)]
	public void Verify_Render_FirstRender(string expectedClass, bool intoView, bool isBackwards)
	{
		IRenderActions<BUIPageLayout> actions = ArrangeThisTest(intoView, isBackwards, true);

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Mock Content");
			a.Render.Find("main").ClassName.Should().BeEquivalentTo(expectedClass);
		});
	}

	[Theory]
	[InlineData("animate__fadeInDown", true, false)]
	public void Verify_Render_SubsequentRenders(string expectedClass, bool intoView, bool isBackwards)
	{
		IRenderActions<BUIPageLayout> actions = ArrangeThisTest(intoView, isBackwards, false);

		actions.Act(a => { });

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Mock Content");
			a.Render.Find("main").ClassName.Should().Contain(expectedClass);
		});
	}

	private IRenderActions<BUIPageLayout> ArrangeThisTest(bool intoView, bool isBackwards, bool isFirstRender)
	{
		return ArrangeRenderTest<BUIPageLayout>(options =>
		{
			Dictionary<string, object> map = new();
			IReadOnlyDictionary<string, object> roMap = new ReadOnlyDictionary<string, object>(map);
			RouteData routeData = new(typeof(Pages.BUIError), roMap);
			options.Parameters.Add("Transition", Transition.Create(routeData, routeData, intoView, isBackwards, isFirstRender));
			options.Parameters.Add("Body", MockRender("Mock Content"));
		}, this.StartupTestServices);
	}
}
