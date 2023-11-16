using Microsoft.AspNetCore.Components;

namespace StoicDreams.BlazorUI.Data;

public class AppOptionsTests : TestFramework
{
    [Fact]
    public void Verify_Usage()
    {
        bool applyStateOnStartup = false;
        IActions<AppOptions> actions = ArrangeUnitTest<AppOptions>(options =>
        {

        });

        actions.Act(a =>
        {
            a.Service.ApplyOnStartup<MockGenericComponent>();
            a.Service.ApplyStateOnStartup(_ => { applyStateOnStartup = true; });
            a.Service.SetLayout<MockLayout>();
            a.Service.SetPageNotFound<MockPageNotFound>();
            a.Service.SetTitleBarContent<MockGenericComponent>();
        });

        actions.Assert(a =>
        {
            applyStateOnStartup.Should().BeFalse();
            a.Service.AppStartupComponent.Should().Be(typeof(MockGenericComponent));
            a.Service.MainLayout.Should().Be(typeof(MockLayout));
            a.Service.PageNotFound.Should().Be(typeof(MockPageNotFound));
            a.Service.TitleBarContent.Should().Be(typeof(MockGenericComponent));
        });

        actions.Act(a =>
        {
            a.Service.ApplyStartupState?.Invoke(Sub<IAppState>());
        });

        actions.Assert(a =>
        {
            applyStateOnStartup.Should().BeTrue();
        });
    }

    public class MockLayout : LayoutComponentBase
    {
    }

    public class MockPageNotFound : ComponentBase
    {
    }

    public class MockGenericComponent : ComponentBase
    {
    }
}
