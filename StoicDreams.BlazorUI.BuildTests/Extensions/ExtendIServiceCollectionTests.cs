using Microsoft.Extensions.DependencyInjection;

namespace StoicDreams.BlazorUI.Extensions;

public class ExtendIServiceCollectionTests : TestFramework
{
	[Fact]
	public void Verify_AddStoicDreamsBlazorUI_Adds_Services()
	{
		IActions<IServiceCollection> actions = ArrangeUnitTest<IServiceCollection, ServiceCollection>();

		actions.Act(a => a.Service.AddStoicDreamsBlazorUI());

		actions.Assert(a => a.GetResult<IServiceCollection>().Should().NotBeNull());
	}
}
