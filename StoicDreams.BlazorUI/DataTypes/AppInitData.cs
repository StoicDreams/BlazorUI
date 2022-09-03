namespace StoicDreams.BlazorUI.DataTypes;

public struct AppInitData
{
	public NavigationManager NavManager { get; set; }
	public IApiRequest ApiRequest { get; set; }
	public IJsInterop JsInterop { get; set; }
	public IClientAuth Auth { get; set; }
	public IAppOptions Options { get; set; }
}
