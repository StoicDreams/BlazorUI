using Microsoft.Extensions.DependencyInjection;

namespace StoicDreams.BlazorUI;

public static class ExtendTestFrameworkBlazor
{
	public static IServiceCollection StartupTestServices(this TestFrameworkBlazor test, IServiceCollection services)
	{
		services.AddMock<IJsInterop>();
		services.AddSingleton<IAppState, AppState>();
		return services;
	}
}
