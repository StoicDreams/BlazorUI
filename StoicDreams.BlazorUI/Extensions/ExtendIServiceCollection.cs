using MudBlazor.Services;

namespace StoicDreams.BlazorUI.Extensions;

public static partial class ExtendIServiceCollection
{
	public static IServiceCollection AddStoicDreamsBlazorUI(this IServiceCollection services,
		Action<IAppOptions>? setupHandler = null,
		Action<MudServicesConfiguration>? mudConfigHandler = null
		)
	{
		IAppOptions appOptions = new AppOptions();
		setupHandler?.Invoke(appOptions);
		services.AddSingleton<IAppOptions>(appOptions);
		services.AddTransient<Data.IJsInterop, JsInterop>();
		services.AddTransient<IApiRequest, ApiRequest>();
		services.SetupStateManagers();
		services.AddMudServices(config =>
		{
			config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomRight;
			config.SnackbarConfiguration.ClearAfterNavigation = false;
			config.SnackbarConfiguration.ShowTransitionDuration = 300;
			config.SnackbarConfiguration.HideTransitionDuration = 300;
			config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
			config.SnackbarConfiguration.MaxDisplayedSnackbars = 10;
			mudConfigHandler?.Invoke(config);
		});
		services.AddScoped<BlazorTransitionableRoute.IRouteTransitionInvoker, BlazorTransitionableRoute.DefaultRouteTransitionInvoker>();
		services.SetupMarkdownSupport();

		return services;
	}

	private static IServiceCollection SetupStateManagers(this IServiceCollection services)
	{
		services.AddSingleton<IPageState, PageState>();
		services.AddSingleton<ISessionState, SessionState>();
		services.AddSingleton<IAppState, AppState>();
		services.AddSingleton<IThemeState, ThemeState>();
		return services;
	}

	private static Assembly AppAssembly => Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
}
