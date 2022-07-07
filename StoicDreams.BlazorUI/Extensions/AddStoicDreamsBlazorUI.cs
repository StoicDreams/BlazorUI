namespace StoicDreams.BlazorUI;

public static partial class Extensions
{
	public static IServiceCollection AddStoicDreamsBlazorUI(this IServiceCollection services, Action<IAppOptions>? setupHandler = null)
	{
		IAppOptions appOptions = new AppOptions();
		setupHandler?.Invoke(appOptions);
		services.AddSingleton<IAppOptions>(appOptions);
		services.AddSingleton<IAppState, AppState>();
		services.AddTransient<IJsInterop, JsInterop>();
		return services;
	}
}
