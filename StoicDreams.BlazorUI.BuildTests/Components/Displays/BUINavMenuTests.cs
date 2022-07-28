using StoicDreams.BlazorUI;

namespace StoicDreams.BlazorUI.Components.Displays;

public class BUINavMenuTests : TestFrameworkBlazor
{
    [Fact]
    public void Verify_Render()
    {
        IRenderActions<BUINavMenu> actions = ArrangeRenderTest<BUINavMenu>(options =>
        {
        }, this.StartupTestServices);

        actions.Act(a =>
        {
        });

        actions.Assert(a =>
        {
            a.Render.HasComponent<MudNavMenu>().Should().BeTrue();
        });
    }
}
