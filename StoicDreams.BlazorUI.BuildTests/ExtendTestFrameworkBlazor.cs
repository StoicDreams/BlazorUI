using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace StoicDreams.BlazorUI;

public static class ExtendTestFrameworkBlazor
{
	public static IServiceCollection StartupTestServices(this TestFrameworkBlazor test, IServiceCollection services)
	{
		services.AddMock<IJsInterop>();
		services.AddMock<IJSRuntime>();
		services.AddMock<IAppOptions>(mock =>
		{
			mock.Setup(m => m.CssFiles).Returns(new List<string>() { "mockcss" });
			mock.Setup(m => m.JavascriptFiles).Returns(new List<string>() { "mockjs" });
			mock.Setup(m => m.HeadElements).Returns(new List<ElementDetail>() { ElementDetail.Create("script") });
			mock.Setup(m => m.BodyElements).Returns(new List<ElementDetail>() { ElementDetail.Create("script") });
		});
		services.AddSingleton<IAppState, AppState>();
		return services;
	}
}
