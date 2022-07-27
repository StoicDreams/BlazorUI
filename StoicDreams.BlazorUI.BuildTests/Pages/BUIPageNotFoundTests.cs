using StoicDreams.BlazorUI;

namespace StoicDreams.BlazorUI.Pages;

public class BUIPageNotFoundTests : TestFrameworkBlazor
{
    [Fact]
    public void Verify_Render()
    {
        IRenderActions<BUIPageNotFound> actions = ArrangeRenderTest<BUIPageNotFound>(_ => { }, this.StartupTestServices);

        actions.Act(a => {
			a.GetService<IAppState>().SetData(AppStateDataTags.NotFoundDefaultMessage, "Not Found A");
			a.Render.SetParametersAndRender();
		});

        actions.Assert(a =>
        {
            a.Render.Markup.Should().Contain("Not Found A");
        });

		actions.Act(a => {
			a.Render.SetParametersAndRender(b => b.Add(c => c.Message, "Not Found B"));
		});

		actions.Assert(a =>
		{
			a.Render.Markup.Should().Contain("Not Found B");
		});
	}
}
