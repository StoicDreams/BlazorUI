namespace StoicDreams.BlazorUI.Defaults;

public static partial class Setup
{
	public static async Task SetupDefaultJsInterop(this Data.IJsInterop interop, IAppOptions options, IAppState appState)
	{
		await interop.AddCSSFile("css/routetransition.4.0.0.min.css");

		foreach (string file in options.CssFiles)
		{
			await interop.AddCSSFile(file);
		}
		foreach (string file in options.JavascriptFiles)
		{
			await interop.AddJSFile(file);
		}
		foreach (ElementDetail detail in options.HeadElements)
		{
			await interop.AddElementToHead(detail.TagName, detail.Attributes);
		}
		foreach (ElementDetail detail in options.BodyElements)
		{
			await interop.AddElementToBody(detail.TagName, detail.Attributes);
		}
		((AppOptions)options).ApplyStartupState?.Invoke(appState);
	}
}
