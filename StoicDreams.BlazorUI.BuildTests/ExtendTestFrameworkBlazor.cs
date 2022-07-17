using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MudBlazor.Services;

namespace StoicDreams.BlazorUI;

public static class ExtendTestFrameworkBlazor
{
	public static IServiceCollection StartupTestServices(this TestFrameworkBlazor test, IServiceCollection services)
	{
		services.AddMock<IJsInterop>();
		services.AddMock<IJSRuntime>();
		AppOptions options = new();
		options.CssFiles.Add("mockcss");
		options.JavascriptFiles.Add("mockjs");
		options.HeadElements.Add(ElementDetail.Create("script"));
		options.BodyElements.Add(ElementDetail.Create("script"));
		services.AddSingleton<IAppOptions>(options);
		services.AddSingleton<IAppState, AppState>();
		services.AddMudServices();
		return services;
	}
}
