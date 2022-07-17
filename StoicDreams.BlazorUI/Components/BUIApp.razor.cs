using System.Reflection;

namespace StoicDreams.BlazorUI.Components;

/// <summary>
/// Top level component required to wrap all other StoicDreams.BlazorUI components.
/// Make sure to configure options for your app with `builder.Services.AddStoicDreamsBlazorUI(options=>{})` in your Program.cs file.
/// </summary>
public partial class BUIApp : ComponentBase, IDisposable
{
	private Assembly AppAssembly => Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
	private Type AppLayout => ((AppOptions)AppOptions).MainLayout;

	private string AppTitle => AppOptions.TitleFormat
			.Replace("{AppName}", AppOptions.AppName)
			.Replace("{PageTitle}", "Page Title")
			;

	protected override async Task OnInitializedAsync()
	{
		await RunSetupFromOptions();
		await base.OnInitializedAsync();
	}

	public void Dispose()
	{
		AppState.UnsubscribeToDataChanges(ComponentId);
	}

	private void HandleDataChanges(IDictionary<string, bool> keys)
	{
		if (!keys.ContainsKey("PageTitle")) { return; }
		InvokeAsync(StateHasChanged);
	}

	private async ValueTask RunSetupFromOptions()
	{
		foreach (string file in AppOptions.CssFiles)
		{
			await JSInterop.AddCSSFile(file);
		}
		foreach (string file in AppOptions.JavascriptFiles)
		{
			await JSInterop.AddJSFile(file);
		}
		foreach (ElementDetail detail in AppOptions.HeadElements)
		{
			await JSInterop.AddElementToHead(detail.TagName, detail.Attributes);
		}
		foreach (ElementDetail detail in AppOptions.BodyElements)
		{
			await JSInterop.AddElementToBody(detail.TagName, detail.Attributes);
		}
	}

	private Guid ComponentId { get; } = Guid.NewGuid();
}
