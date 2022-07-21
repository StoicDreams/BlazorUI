using MudBlazor.Services;

namespace StoicDreams.BlazorUI.Extensions;

public static partial class ExtendIServiceCollection
{
	public static IServiceCollection AddStoicDreamsBlazorUI(this IServiceCollection services, Action<IAppOptions>? setupHandler = null)
	{
		IAppOptions appOptions = new AppOptions();
		appOptions.CssFiles.Add($"{AppAssembly.GetName().Name}.styles.css");
		setupHandler?.Invoke(appOptions);
		services.AddSingleton<IAppOptions>(appOptions);
		services.AddSingleton<IAppState, AppState>();
		services.AddTransient<Data.IJsInterop, JsInterop>();
		services.AddMudServices();
		services.AddScoped<BlazorTransitionableRoute.IRouteTransitionInvoker, BlazorTransitionableRoute.DefaultRouteTransitionInvoker>();

		return services;
	}
	private static Assembly AppAssembly => Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();

}
